using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public TotemCompletion totem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        totem.isPickup = true;
        totem.orb=gameObject;
    }

    public void Drop()
    {
        totem.isPickup = false;
    }
}
