// Скрипт, що повертає час гри у норму
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTime : MonoBehaviour
{
    public void TimeRefresh()
    {
        Time.timeScale = 1;
    }
}