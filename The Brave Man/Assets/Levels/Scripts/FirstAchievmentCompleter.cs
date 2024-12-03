using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAchievmentCompleter : MonoBehaviour
{
    public float achievmenttimer = 2.0f;

    private bool hasShownAchievement = false;

    public Image achievementCompletedImage;

    public static bool levelCompletedAchievment = false;

    void Start()
    {
        // ������� �������� ��� ������������ ���������� ������
        levelCompletedAchievment = true;

        // ��������� ��������� ������ ���������� �� ���������� ������
        hasShownAchievement = PlayerPrefs.GetInt("HasShownAchievement", 0) == 1;

        if (levelCompletedAchievment && !hasShownAchievement)
        {
            // ���� ������� ��� �������� � ��� �� ������������ ����������, ���������� Image
            ShowAchievementCompletedImage();

            // ������������� ����, ��� ���������� ���� ��������
            hasShownAchievement = true;

            // ��������� ��������� ������ ����������
            PlayerPrefs.SetInt("HasShownAchievement", hasShownAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }

        // �� ���������� ������ ��� �������� ����� ����
        DontDestroyOnLoad(gameObject);
    }

    // ����� ��� ������ Image �� 3 �������
    private void ShowAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(true);
        Invoke("HideAchievementCompletedImage", achievmenttimer);
    }

    // ����� ��� ������� Image
    private void HideAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(false);
    }
}