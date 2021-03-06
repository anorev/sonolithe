using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior player;

    [SerializeField]
    private AudioSource audio;
/*    public float delay = 0.000000001F;
    private float time = 0;*/
    // Start is called before the first frame update
    void Start()
    {
        // audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsMoving() && player.IsGrounded() && !audio.isPlaying)
        {
            audio.volume = Random.Range(.6f, .8f);
            audio.pitch = Random.Range(.8f,.1f);
            audio.Play();
        }
    }
}
