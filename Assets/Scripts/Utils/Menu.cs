using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;



public class Menu : MonoBehaviour
{
    public CanvasGroup Ui;
    [SerializeField]
    private VideoPlayer VideoCutscene;

    public void startGame()
    {
        StartCoroutine(Fade());
        VideoCutscene.Play();

    }

    public void Update()
    {
        if ((VideoCutscene.frame) > 0 && (VideoCutscene.isPlaying == false))
        {
            EndReached();
        }
    }

    private void EndReached()
    {
        SceneManager.LoadScene(1);
    }

    private IEnumerator Fade()
    {
        float time = 0f;
        float progress = 0f;
        float Duration = 3f;
        while (time <= Duration)
        {
            time += Time.deltaTime;
            progress = time / Duration;
            Ui.alpha = 1f - progress;
            yield return null;
        }

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
