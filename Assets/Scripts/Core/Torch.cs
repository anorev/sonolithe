using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject objTorch;
    public bool isPicked = false;

    // Update is called once per frame
    void Update()
    {
        if(isPicked)
        {
            objTorch.SetActive(!objTorch.activeSelf); // Inverser l'état de la lumière
        }
        
    }
}
