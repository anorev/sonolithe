using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class TotemCompletionManager : MonoBehaviour
{
    public TotemCompletion[] totemCompletionArray;
    public List<bool> booleanArray;
    [SerializeField]
    GameObject portalSphere;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    CinemachineVirtualCamera endCutsceneCamera;
    [SerializeField]
    Light _endLight;
    [SerializeField]
    AudioSource _finalTrack;
    [SerializeField]
    GameObject totem3;
    AudioSource _totem3Track;
    [SerializeField]
    GameObject totem2;
    AudioSource _totem2Track;
    [SerializeField]
    GameObject totem1;
    AudioSource _totem1Track;
    bool lookAtIng = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totemCompletionArray.Length; i++)
        {
            totemCompletionArray[i].OnTotemCompleted += CheckTotemTotal;
        }


    }

    private void Update()
    {
        if (lookAtIng)
        {
            GameObject.Find("Player").transform.LookAt(portalSphere.transform);
        }
    }

    private void portalApparition()
    {
        _endLight.gameObject.SetActive(true);
        lookAtIng = true;
        endCutsceneCamera.m_LookAt = portalSphere.transform;
       //player.GetComponent<PlayerBehavior>().enabled = false;
       Sequence seq = DOTween.Sequence();
        seq.AppendInterval(5f).Append(portalSphere.transform.DOScale(
        3f, 2f).SetEase(Ease.InOutBounce))
       .AppendInterval(1f).Append(portalSphere.transform.DOMove(
        new Vector3(-52.15f, 5.25f, -79f), 6f))
        .AppendInterval(0f).Append(portalSphere.transform.DOScale(
        8f, 1f).SetEase(Ease.InOutBounce)).Join(_endLight.DOIntensity(
        3000f, 1f).SetEase(Ease.InOutSine));

    }

    private void CheckTotemTotal(bool isTotemCompleted, string name)
    {
        booleanArray.Add(isTotemCompleted);

        //= totemCompletionArray.Length

        if (booleanArray.Count >= totemCompletionArray.Length)
        {
            _totem3Track = totem3.GetComponent<TotemController>().totemTrack;
            _totem2Track = totem2.GetComponent<TotemController>().totemTrack;
            _totem1Track = totem1.GetComponent<TotemController>().totemTrack;

            _finalTrack.Play();
            _totem3Track.Stop();
            _totem2Track.Stop();
            _totem1Track.Stop();
            portalApparition();

        }
    }
}
