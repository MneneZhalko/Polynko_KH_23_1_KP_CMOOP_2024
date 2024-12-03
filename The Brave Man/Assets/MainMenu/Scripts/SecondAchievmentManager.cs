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
        // «агружаем состо€ние достижени€
        secondAchievementUnlocked = PlayerPrefs.GetInt("SecondAchievementUnlocked", 0) == 1;

        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        // ѕровер€ем булевое значение в LevelManager
        if (SecondAchievmentCompleter.hasShownSecondAchievement)
        {
            // ƒостижение выполнено
            UnlockAchievement();

            // ќбновл€ем UI дл€ отображени€ текущего состо€ни€ достижени€
            UpdateAchievementUI();

            // —брасываем значение в LevelManager, чтобы не сработало в следующий раз
            SecondAchievmentCompleter.hasShownSecondAchievement = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (secondAchievementImage != null && secondAchievementUnlockedSprite != null)
        {
            // »змен€ем изображение в зависимости от выполнени€ достижени€
            secondAchievementImage.sprite = secondAchievementUnlocked ? secondAchievementUnlockedSprite : secondAchievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        // ”станавливаем achievementUnlocked в true
        secondAchievementUnlocked = true;

        // —охран€ем состо€ние достижени€
        PlayerPrefs.SetInt("SecondAchievementUnlocked", secondAchievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}
