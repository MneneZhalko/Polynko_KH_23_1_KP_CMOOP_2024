using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdAchievmentIMG : MonoBehaviour
{
    public float achievementTimer = 2.0f;
    public static bool hasShownThirdAchievementIMG = false;

    public Image achievementCompletedImage;

    void Start()
    {
        // ��������� ��������� ������ ���������� �� ���������� ������
        hasShownThirdAchievementIMG = PlayerPrefs.GetInt("hasShownThirdAchievementIMG", 0) == 1;

        // ³����� ������ ����������, ���� ���� ���� �������� �����
        if (hasShownThirdAchievementIMG)
        {
            achievementCompletedImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (ThirdAchievmentCompleter.hasShownThirdAchievement && !hasShownThirdAchievementIMG)
        {
            // ���������� ����, �� ���������� ���� ��������
            hasShownThirdAchievementIMG = true;
            PlayerPrefs.SetInt("hasShownThirdAchievementIMG", hasShownThirdAchievementIMG ? 1 : 0);
            PlayerPrefs.Save();

            // �������� ���������� ����������
            ShowAchievementCompletedImage();
        }
    }

    // ����� ��� ������ ���������� �� ������ ���
    private void ShowAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(true);
        Invoke("HideAchievementCompletedImage", achievementTimer);
    }

    // ����� ��� ������� ����������
    private void HideAchievementCompletedImage()
    {
        achievementCompletedImage.gameObject.SetActive(false);
    }
}