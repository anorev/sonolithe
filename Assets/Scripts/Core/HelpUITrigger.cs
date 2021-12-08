using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HelpUITrigger : MonoBehaviour
{
        public TextMeshProUGUI orbHelp;

    // Start is called before the first frame update
    void Start()
    {
        orbHelp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other) 
    {   
        if (other.CompareTag("Player")) 
        {
            orbHelp.gameObject.SetActive(true);
        }
    }

        private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            orbHelp.gameObject.SetActive(false);
        }
    }
}
