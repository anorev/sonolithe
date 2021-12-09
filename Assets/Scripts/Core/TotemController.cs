using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TotemController : MonoBehaviour
{
    public TotemCompletion totem;
    public Transform[] recipients;
    PlayerInput playerInput;
    private bool isEventSent;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();

    }

    void Start()
    {
        recipients = transform.Find("Recipients").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!totem.isPickup && totem.orb && Vector3.Distance(transform.position, totem.orb.transform.position) <= 5f)
        {

            for (int i = 0; i < 3; i++)
            {
                if (recipients[i].childCount == 0 && totem.orb.CompareTag(totem.name))
                {
                    totem.orb.transform.parent = recipients[i];
                    totem.isPickup = true;

                    totem.orb.GetComponent<Rigidbody>().isKinematic = true;
                    totem.orb.transform.DOLocalMove(new Vector3(0, 0, 0), 2);
                    totem.orb.transform.localScale = totem.orbScale;
                    AddOrb();

                }
                else if (!totem.orb.CompareTag(totem.name))
                {

                    totem.orb.transform.DOShakeRotation(0.5f, 0.5f, 10, fadeOut: true);
                }
                if (checkTotem() && !isEventSent)
                {
                    totem.completeTotem(true, totem.name);
                    isEventSent = true;
                }
            }
        }
    }
    public bool checkTotem()
    {
        for (int i = 0; i < recipients.Length; ++i)
        {
            if (recipients[i].childCount < 1)
            {
                return false;
            }
        }

        return true;
    }

    public void AddOrb()
    {
        if (transform.Find("nervure").GetComponent<Renderer>().material.GetFloat("_Progress") < 0.5)
        {
            StartCoroutine(IncreaseVeinEmission(0.5f));
        }
        else
        {
            StartCoroutine(IncreaseVeinEmission(1f));
        }
    }



    IEnumerator IncreaseVeinEmission(float target)
    {
        float lerpDuration = 4;
        float startValue = transform.Find("nervure").GetComponent<Renderer>().material.GetFloat("_Progress");
        float endValue = target;
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.Find("nervure").GetComponent<Renderer>().material.SetFloat("_Progress", Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.Find("nervure").GetComponent<Renderer>().material.SetFloat("_Progress", target);
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

