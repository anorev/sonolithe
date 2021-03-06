using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public TotemCompletion totem;
    [SerializeField]
    private float pulseTempo;
    private GameObject orbTorch;
    private Color _emissionColor;

    [SerializeField]
    public AudioSource drop;
    [SerializeField]
    public AudioSource pickup;

    [SerializeField]
    public AudioSource orbEnter;
    // [SerializeField]
    // public AudioSource orbTrack;

    public AudioSource pulseSource;
    [SerializeField]
    public float timeBetweenShots;
    float timer;

    bool hasPulseBeenStopped;


    // Start is called before the first frame update
    void Start()
    {
        totem.orb = gameObject;
        orbTorch = transform.Find("Torch").gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;
        if (timer > timeBetweenShots && !transform.parent)
        {
            float emissionIntensity = Mathf.Sin(Time.time * pulseTempo) * 0.5f + 0.5f;
            transform.Find("Sphere.001").gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", _emissionColor * emissionIntensity);
            pulseSource.Play();
            timer = 0;
        }
        else if (transform.parent && transform.parent.CompareTag("TotemModel") && !hasPulseBeenStopped)
        {
            pulseSource.Stop();
            hasPulseBeenStopped = true;
        }

    }

    public void Pickup()
    {
        totem.isPickup = true;
        totem.orb = gameObject;
        orbTorch.SetActive(true);
        pickup.Play();
    }

    public void Drop()
    {
        totem.isPickup = false;
        orbTorch.SetActive(false);
        drop.Play(); // TODO: Make collision sound 
    }


}
