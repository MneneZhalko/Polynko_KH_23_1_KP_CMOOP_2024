using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStopper : MonoBehaviour
{
    public GameObject pausePanel; // Ссылка на вашу панель в инспекторе Unity

    void Start()
    {
        Time.timeScale = 1; // Возобновляем время
    }
}
