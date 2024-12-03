using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdAchievmentIMG : MonoBehaviour
{
    public float achievementTimer = 2.0f;
    public static bool hasShownThirdAchievementIMG = false;

    public Image achievementCompletedImage;

    void Start()
    {
        // Загружаем состояние показа достижения из предыдущей сессии
        hasShownThirdAchievementIMG = PlayerPrefs.GetInt("hasShownThirdAchievementIMG", 0) == 1;

        // Відразу ховаємо зображення, якщо воно було показане раніше
        if (hasShownThirdAchievementIMG)
        {
            achievementCompletedImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (ThirdAchievmentCompleter.hasShownThirdAchievement && !hasShownThirdAchievementIMG)
        {
            // Встановити флаг, що досягнення було показано
            hasShownThirdAchievementIMG = true;
            PlayerPrefs.SetInt("hasShownThirdAchievementIMG", hasShownThirdAchievementIMG ? 1 : 0);
            PlayerPrefs.Save();

            // Показати зображення досягнення
            ShowAchievementCompletedImage();
        }
    }

    // Метод для показу зображення на певний час
    private void ShowAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(true);
        Invoke("HideAchievementCompletedImage", achievementTimer);
    }

    // Метод для ховання зображення
    private void HideAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(false);
    }
}