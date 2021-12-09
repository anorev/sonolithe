using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TotemCompletionManager : MonoBehaviour
{
    public TotemCompletion[] totemCompletionArray;
    public List<bool> booleanArray;
    public GameObject portalSphere;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totemCompletionArray.Length; i++)
        {
            totemCompletionArray[i].OnTotemCompleted += CheckTotemTotal;
        }

    }


    // Update is called once per frame
    private void CheckTotemTotal(bool isTotemCompleted, string name)
    {
        booleanArray.Add(isTotemCompleted);

        if (booleanArray.Count >= totemCompletionArray.Length)
        {
            Debug.Log("Tous les totems sont complets");

        }
    }
}
