using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthAchievmentManager : MonoBehaviour
{
    public Image fourthAchievementImage;
    public Sprite fourthAchievementUnlockedSprite;
    public Sprite fourthAchievementBlockedSprite;

    public bool fourthAchievementUnlocked = false;

    void Start()
    {
        // «агружаем состо€ние достижени€
        fourthAchievementUnlocked = PlayerPrefs.GetInt("FourthAchievementUnlocked", 0) == 1;

        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        // ѕровер€ем булевое значение в LevelManager
        if (FourthAchievmentCompleter.hasShownFourthAchievement)
        {
            // ƒостижение выполнено
            UnlockAchievement();

            // ќбновл€ем UI дл€ отображени€ текущего состо€ни€ достижени€
            UpdateAchievementUI();

            // —брасываем значение в LevelManager, чтобы не сработало в следующий раз
            FourthAchievmentCompleter.hasShownFourthAchievement = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (fourthAchievementImage != null && fourthAchievementUnlockedSprite != null)
        {
            // »змен€ем изображение в зависимости от выполнени€ достижени€
            fourthAchievementImage.sprite = fourthAchievementUnlocked ? fourthAchievementUnlockedSprite : fourthAchievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        // ”станавливаем achievementUnlocked в true
        fourthAchievementUnlocked = true;

        // —охран€ем состо€ние достижени€
        PlayerPrefs.SetInt("FourthAchievementUnlocked", fourthAchievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}