using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/TotemCompletion")]
public class TotemCompletion : ScriptableObject
{
    public delegate void TotemEvent(bool isTotemCompleted, string name);
    public event TotemEvent OnTotemCompleted;

    public GameObject totem;
    public GameObject orb;
    public bool isPickup;
    public bool isComplete;
    public Vector3 orbScale;

    void Awake()
    {
        isComplete = false;
    }

    public void completeTotem(bool _isTotemCompleted, string _name)
    {
        isComplete = true;
        isPickup = false;
        OnTotemCompleted?.Invoke(_isTotemCompleted, _name);
    }
}


