using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchEndFadeOut : MonoBehaviour

{
    [SerializeField]
    CanvasGroup _whiteCanvas;
    bool _hasEndBeenDisplayed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_hasEndBeenDisplayed)
        {
            _whiteCanvas.gameObject.SetActive(true);
            StartCoroutine(FadeOut());
            _hasEndBeenDisplayed = true;
        }
    }
    private IEnumerator FadeOut()
    {
        float time = 0f;
        float progress = 0f;
        float Duration = 2f;
        while (time <= Duration)
        {
            time += Time.deltaTime;
            progress = time / Duration;
            _whiteCanvas.alpha = 0f + progress;
            yield return null;
        }
        quitGame();

    }
    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
