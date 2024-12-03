using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAchievmentCompleter : MonoBehaviour
{
    public float achievmenttimer = 2.0f;

    private bool hasShownAchievement = false;

    public Image achievementCompletedImage;

    public static bool levelCompletedAchievment = false;

    void Start()
    {
        // Булевое значение для отслеживания завершения уровня
        levelCompletedAchievment = true;

        // Загружаем состояние показа достижения из предыдущей сессии
        hasShownAchievement = PlayerPrefs.GetInt("HasShownAchievement", 0) == 1;

        if (levelCompletedAchievment && !hasShownAchievement)
        {
            // Если уровень был завершен и еще не показывалось достижение, показываем Image
            ShowAchievementCompletedImage();

            // Устанавливаем флаг, что достижение было показано
            hasShownAchievement = true;

            // Сохраняем состояние показа достижения
            PlayerPrefs.SetInt("HasShownAchievement", hasShownAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }

        // Не уничтожать объект при загрузке новых сцен
        DontDestroyOnLoad(gameObject);
    }

    // Метод для показа Image на 3 секунды
    private void ShowAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(true);
        Invoke("HideAchievementCompletedImage", achievmenttimer);
    }

    // Метод для скрытия Image
    private void HideAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(false);
    }
}
