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
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsMoving() && player.IsGrounded() && !audio.isPlaying)
        {
            audio.Play();
        }
        
    }
}
