using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollisionSkeleton : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSource;
    bool _hasBeenPlayed;
    [SerializeField]
    GameObject _skull;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audioSource.isPlaying && !_hasBeenPlayed)
        {
            audioSource.Play();
            StartCoroutine(waitCoroutine());
            _hasBeenPlayed = true;
        }
    }

    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(2);
        _skull.GetComponent<Rigidbody>().isKinematic = false;
    }
}