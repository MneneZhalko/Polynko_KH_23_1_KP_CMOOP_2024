using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLvl2 : MonoBehaviour
{
    public Image BlockedLvl2;
    public Image Zapus2;

    void Start()
    {
        // ѕерев≥р€Їмо стан показу дос€гненн€ з PlayerPrefs
        bool hasShownThirdAchievement = PlayerPrefs.GetInt("hasShownThirdAchievement", 0) == 1;

        // якщо дос€гненн€ вже було показано, вимикаЇмо зображенн€
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