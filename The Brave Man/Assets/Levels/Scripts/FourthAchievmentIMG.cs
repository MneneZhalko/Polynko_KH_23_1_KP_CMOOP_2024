using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthAchievmentIMG : MonoBehaviour
{
    public float achievementTimer = 2.0f;
    public static bool hasShownFourthAchievementIMG = false;

    public Image achievementCompletedImage;

    void Start()
    {
        // Загружаем состояние показа достижения из предыдущей сессии
        hasShownFourthAchievementIMG = PlayerPrefs.GetInt("hasShownFourthAchievementIMG", 0) == 1;

        // Відразу ховаємо зображення, якщо воно було показане раніше
        if (hasShownFourthAchievementIMG)
        {
            achievementCompletedImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {

        if (FourthAchievmentCompleter.hasShownFourthAchievement && !hasShownFourthAchievementIMG)
        {
            // Встановити флаг, що досягнення було показано
            hasShownFourthAchievementIMG = true;
            PlayerPrefs.SetInt("hasShownFourthAchievementIMG", hasShownFourthAchievementIMG ? 1 : 0);
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