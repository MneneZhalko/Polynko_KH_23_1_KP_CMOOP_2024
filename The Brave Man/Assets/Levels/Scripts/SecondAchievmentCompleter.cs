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
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        hasShownSecondAchievement = PlayerPrefs.GetInt("hasShownSecondAchievement", 0) == 1;
        enemyKilledAchievement = PlayerPrefs.GetInt("enemyKilledAchievement", 0) == 1;

        if (enemyKilledAchievement && !hasShownSecondAchievement)
        {
            hasShownSecondAchievement = true;

            PlayerPrefs.SetInt("hasShownSecondAchievement", hasShownSecondAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
