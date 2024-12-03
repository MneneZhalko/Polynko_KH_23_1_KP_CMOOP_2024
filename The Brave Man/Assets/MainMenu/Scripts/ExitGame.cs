// Скрипт для виходу з гри
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void StopGame()
    {
        Application.Quit();
    }
}