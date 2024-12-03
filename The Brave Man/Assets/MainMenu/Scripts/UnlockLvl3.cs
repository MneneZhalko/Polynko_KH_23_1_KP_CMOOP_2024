// Скрипт, що розблоковує рівні
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLvl3 : MonoBehaviour
{
    public Image BlockedLvl2;
    public Image Zapus2;

    void Start()
    {
        bool hasShownThirdAchievement = PlayerPrefs.GetInt("hasShownFourthAchievement", 0) == 1;
        Debug.Log(hasShownThirdAchievement);

        if (hasShownThirdAchievement)
        {
            BlockedLvl2.gameObject.SetActive(false);
            Zapus2.gameObject.SetActive(true);
        }
        else
        {
            BlockedLvl2.gameObject.SetActive(true);
        }
    }
}