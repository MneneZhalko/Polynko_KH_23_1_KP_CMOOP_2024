using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondAchievmentManager : MonoBehaviour
{
    public Image secondAchievementImage;
    public Sprite secondAchievementUnlockedSprite;
    public Sprite secondAchievementBlockedSprite;

    public bool secondAchievementUnlocked = false;

    void Start()
    {
        secondAchievementUnlocked = PlayerPrefs.GetInt("SecondAchievementUnlocked", 0) == 1;

        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        if (SecondAchievmentCompleter.hasShownSecondAchievement)
        {
            UnlockAchievement();

            UpdateAchievementUI();

            SecondAchievmentCompleter.hasShownSecondAchievement = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (secondAchievementImage != null && secondAchievementUnlockedSprite != null)
        {
            secondAchievementImage.sprite = secondAchievementUnlocked ? secondAchievementUnlockedSprite : secondAchievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        secondAchievementUnlocked = true;

        PlayerPrefs.SetInt("SecondAchievementUnlocked", secondAchievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}
