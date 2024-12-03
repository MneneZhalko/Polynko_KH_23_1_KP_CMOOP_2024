using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthAchievmentCompleter : MonoBehaviour
{
    public static bool humansSavedCompletedAchievement = false;
    public static bool hasShownFourthAchievement = false;
    public int savedHumans = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        savedHumans = HumanCircle.GetTotalSaved();

        humansSavedCompletedAchievement = PlayerPrefs.GetInt("humansSavedCompletedAchievement", 0) == 1;
        hasShownFourthAchievement = PlayerPrefs.GetInt("hasShownFourthAchievement", 0) == 1;

        if (savedHumans == 3 && !humansSavedCompletedAchievement)
        {
            humansSavedCompletedAchievement = true;
            PlayerPrefs.SetInt("humansSavedCompletedAchievement", humansSavedCompletedAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }

        if (humansSavedCompletedAchievement && !hasShownFourthAchievement)
        {
            hasShownFourthAchievement = true;
            PlayerPrefs.SetInt("hasShownFourthAchievement", hasShownFourthAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}