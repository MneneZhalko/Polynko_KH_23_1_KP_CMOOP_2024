// Скрипт для плавного переходу між сценами
using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableFadeOut", 1f);
    }

    void DisableFadeOut()
    {
        GameObject fadeOutPanel = GameObject.Find("Fade Out");
        if (fadeOutPanel != null)
        {
            fadeOutPanel.SetActive(false);
        }
    }
}