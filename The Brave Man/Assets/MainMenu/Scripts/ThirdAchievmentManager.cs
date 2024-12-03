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
        // ��������� ��������� ����������
        thirdAchievementUnlocked = PlayerPrefs.GetInt("ThirdAchievementUnlocked", 0) == 1;

        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        // ��������� ������� �������� � LevelManager
        if (ThirdAchievmentCompleter.hasShownThirdAchievement)
        {
            // ���������� ���������
            UnlockAchievement();

            // ��������� UI ��� ����������� �������� ��������� ����������
            UpdateAchievementUI();

            // ���������� �������� � LevelManager, ����� �� ��������� � ��������� ���
            ThirdAchievmentCompleter.hasShownThirdAchievement = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (thirdAchievementImage != null && thirdAchievementUnlockedSprite != null)
        {
            // �������� ����������� � ����������� �� ���������� ����������
            thirdAchievementImage.sprite = thirdAchievementUnlocked ? thirdAchievementUnlockedSprite : thirdAchievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        // ������������� achievementUnlocked � true
        thirdAchievementUnlocked = true;

        // ��������� ��������� ����������
        PlayerPrefs.SetInt("ThirdAchievementUnlocked", thirdAchievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}
