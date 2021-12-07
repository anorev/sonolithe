using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    private bool hasPlayer = false;
    public bool beingCarried = false;
    private bool touched = false;
    PlayerInput playerInput;
    Vector3 orbScale;
    //public Light orbTorch;




    // Start is called before the first frame update
    void Awake()
    {
        // initially set reference variables
        playerInput = new PlayerInput();
        orbScale = new Vector3(4f, 4f, 4f);

    }

    // detection de contact grace au collider is trigger 
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //check distance entre player et objet 
        float dist = Vector3.Distance(transform.position, player.position);

        //si inferier ou �gal � 1.9 == on peut ramasser 
        if (dist <= 4f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        // et si on peut ramasser et qu'on appuie sur E = on porte l'objet 
        if (playerInput.CharacterControls.Grab.triggered)
        {

            if (hasPlayer && !beingCarried)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                Vector3 orbScale = transform.localScale;
                transform.parent = playerCam;
                transform.DOLocalMove(new Vector3(0, -0.1f, 2.5f), 0.3f);
                transform.localScale = orbScale;

                beingCarried = true;
                //c = !orbTorch.enabled; // Inverser l'etat de la lumiere

                GetComponent<OrbController>().Pickup();
                // orbTorch.enabled = !orbTorch.enabled; // Inverser l'etat de la lumiere

            }

            else if (beingCarried)
            {
                if (transform.parent == playerCam)
                {
                    GetComponent<OrbController>().Drop();
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    transform.localScale = orbScale;
                    beingCarried = false;
                }
                else if (transform.parent != playerCam)

                {
                    beingCarried = true;

                }
            }
            /*
                        else
                        {
                            orbTorch.enabled = false;
                        }

                        if(beingCarried) {
                            objTorch.SetActive(orbTorch.activeSelf);
                            Debug.Log(orbTorch.activeSelf);
                            orbTorch.enabled = true;
                        } else {
                            orbTorch.enabled = false;
                            objTorch.SetActive(!orbTorch.activeSelf);

                        }
            */


        }


        // si on porte objet 
        if (touched)
        {
            //si objet touche mur / collider 
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            beingCarried = false;
            GetComponent<OrbController>().Drop();

        }
    }
    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterControls.Disable();

    }
}
