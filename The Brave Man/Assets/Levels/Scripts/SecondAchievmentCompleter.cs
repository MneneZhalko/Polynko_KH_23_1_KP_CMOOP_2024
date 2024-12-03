using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondAchievmentCompleter : MonoBehaviour
{
    public static bool hasShownSecondAchievement = false;
    public static bool enemyKilledAchievement = false;

    void Start()
    {
        // Не уничтожать объект при загрузке новых сцен
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Загружаем состояние показа достижения из предыдущей сессии
        hasShownSecondAchievement = PlayerPrefs.GetInt("hasShownSecondAchievement", 0) == 1;
        enemyKilledAchievement = PlayerPrefs.GetInt("enemyKilledAchievement", 0) == 1;

        if (enemyKilledAchievement && !hasShownSecondAchievement)
        {
            // Устанавливаем флаг, что достижение было показано
            hasShownSecondAchievement = true;

            // Сохраняем состояние показа достижения
            PlayerPrefs.SetInt("hasShownSecondAchievement", hasShownSecondAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
