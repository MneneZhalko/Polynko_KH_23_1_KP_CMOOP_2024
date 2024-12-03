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
        // ��������� ��������� ����������
        fourthAchievementUnlocked = PlayerPrefs.GetInt("FourthAchievementUnlocked", 0) == 1;

        UpdateAchievementUI();
    }

    void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        // ��������� ������� �������� � LevelManager
        if (FourthAchievmentCompleter.hasShownFourthAchievement)
        {
            // ���������� ���������
            UnlockAchievement();

            // ��������� UI ��� ����������� �������� ��������� ����������
            UpdateAchievementUI();

            // ���������� �������� � LevelManager, ����� �� ��������� � ��������� ���
            FourthAchievmentCompleter.hasShownFourthAchievement = false;
        }
    }

    private void UpdateAchievementUI()
    {
        if (fourthAchievementImage != null && fourthAchievementUnlockedSprite != null)
        {
            // �������� ����������� � ����������� �� ���������� ����������
            fourthAchievementImage.sprite = fourthAchievementUnlocked ? fourthAchievementUnlockedSprite : fourthAchievementBlockedSprite;
        }
    }

    private void UnlockAchievement()
    {
        // ������������� achievementUnlocked � true
        fourthAchievementUnlocked = true;

        // ��������� ��������� ����������
        PlayerPrefs.SetInt("FourthAchievementUnlocked", fourthAchievementUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}