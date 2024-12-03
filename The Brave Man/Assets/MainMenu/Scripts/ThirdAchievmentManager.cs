using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdAchievmentManager : MonoBehaviour
{
    public Image thirdAchievementImage;
    public Sprite thirdAchievementUnlockedSprite;
    public Sprite thirdAchievementBlockedSprite;

    public bool thirdAchievementUnlocked = false;

    void Start()
    {
        // «агружаем состо€ние достижени€
        thirdAchievementUnlocked = PlayerPrefs.GetInt("ThirdAchievementUnlocked", 0) == 1;

        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        // ѕровер€ем булевое значение в LevelManager
        if (ThirdAchievmentCompleter.hasShownThirdAchievement)
        {
            // ƒостижение выполнено
            UnlockAchievement();

            // ќбновл€ем UI дл€ отображени€ текущего состо€ни€ достижени€
            UpdateAchievementUI();

            // —брасываем значение в LevelManager, чтобы не сработало в следующий раз
            ThirdAchievmentCompleter.hasShownThirdAchievement = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (thirdAchievementImage != null && thirdAchievementUnlockedSprite != null)
        {
            // »змен€ем изображение в зависимости от выполнени€ достижени€
            thirdAchievementImage.sprite = thirdAchievementUnlocked ? thirdAchievementUnlockedSprite : thirdAchievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        // ”станавливаем achievementUnlocked в true
        thirdAchievementUnlocked = true;

        // —охран€ем состо€ние достижени€
        PlayerPrefs.SetInt("ThirdAchievementUnlocked", thirdAchievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}
