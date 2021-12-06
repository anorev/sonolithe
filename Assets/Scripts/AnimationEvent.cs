using UnityEngine;
using System.Collections;
using DG.Tweening;
using Cinemachine;
public class AnimationEvent : MonoBehaviour
{

    private bool isCutsceneFinished;
    private bool isCameraSwitched;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cutsceneCamera;
    [SerializeField]
    private GameObject fpsCamera;
    [SerializeField]

    CinemachineVirtualCamera vcam;
    public void Start()
    {

        player.GetComponent<PlayerBehavior>().enabled = false;

    }
    public void Update()
    {
        if (isCutsceneFinished && !isCameraSwitched)
        {
            cutsceneCamera.SetActive(false);
            player.GetComponent<PlayerBehavior>().enabled = true;
            vcam.m_LookAt = null;
            fpsCamera.SetActive(true);
            //player.transform.Find("Main Camera").transform.DOLookAt(transform.position, 0.5);
            isCameraSwitched = true;

        }
    }
    
    public void setIsCutsceneFinished()
    {
        isCutsceneFinished=true;
    }
}