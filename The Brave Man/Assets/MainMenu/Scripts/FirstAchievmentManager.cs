// —крипт дл€ виконанн€ одного з дос€гнень
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAchievmentManager : MonoBehaviour
{
    public Image achievementImage;
    public Sprite achievementUnlockedSprite;
    public Sprite achievementBlockedSprite;

    public bool achievementUnlocked = false;

    void Start()
    {
        achievementUnlocked = PlayerPrefs.GetInt("FirstAchievementUnlocked", 0) == 1;
        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        if (FirstAchievmentCompleter.levelCompletedAchievment)
        {
            UnlockAchievement();

            UpdateAchievementUI();

            FirstAchievmentCompleter.levelCompletedAchievment = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (achievementImage != null && achievementUnlockedSprite != null)
        {
            achievementImage.sprite = achievementUnlocked ? achievementUnlockedSprite : achievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        achievementUnlocked = true;

        PlayerPrefs.SetInt("FirstAchievementUnlocked", achievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}
