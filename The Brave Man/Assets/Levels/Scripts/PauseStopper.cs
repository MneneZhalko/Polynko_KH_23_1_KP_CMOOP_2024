using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStopper : MonoBehaviour
{
    public GameObject pausePanel;

    void Start()
    {
        Time.timeScale = 1;
    }
}
