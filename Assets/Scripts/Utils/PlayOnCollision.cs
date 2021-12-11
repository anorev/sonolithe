using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSource;
    bool _hasBeenPlayed;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audioSource.isPlaying && !_hasBeenPlayed)
        {
            audioSource.Play();
            _hasBeenPlayed = true;
        }
    }
}