using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondAchievmentIMG : MonoBehaviour
{
    public float achievmenttimer = 2.0f;

    public static bool hasShownSecondAchievementIMG = false;

    public Image achievementCompletedImage;

    void Start()
    {
        hasShownSecondAchievementIMG = PlayerPrefs.GetInt("hasShownSecondAchievementIMG", 0) == 1;
    }

    void Update()
    {
        if (SecondAchievmentCompleter.hasShownSecondAchievement && !hasShownSecondAchievementIMG)
        {
            hasShownSecondAchievementIMG = true;
            PlayerPrefs.SetInt("hasShownSecondAchievementIMG", hasShownSecondAchievementIMG ? 1 : 0);
            PlayerPrefs.Save();
            ShowAchievementCompletedImage();
        }
    }

    private void ShowAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(true);
        Invoke("HideAchievementCompletedImage", achievmenttimer);
    }

    private void HideAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(false);
    }
}
