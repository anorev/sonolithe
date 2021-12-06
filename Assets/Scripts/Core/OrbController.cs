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
    // Start is called before the first frame update
    void Start()
    {
        orbTorch = transform.Find("Torch").gameObject;
         _emissionColor = transform.Find("signal.001").gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
        //InvokeRepeating("ChangeColor", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float emissionIntensity=Mathf.Sin(Time.time * pulseTempo)*0.5f+0.5f;
        transform.Find("signal.001").gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", _emissionColor * emissionIntensity);
    }

    public void Pickup()
    {
        totem.isPickup = true;
        totem.orb = gameObject;
        orbTorch.SetActive(true);
    }

    public void Drop()
    {
        totem.isPickup = false;
        orbTorch.SetActive(false);

    }
}
