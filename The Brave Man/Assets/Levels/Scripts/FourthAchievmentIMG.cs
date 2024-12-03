using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthAchievmentIMG : MonoBehaviour
{
    public float achievementTimer = 2.0f;
    public static bool hasShownFourthAchievementIMG = false;

    public Image achievementCompletedImage;

    void Start()
    {
        // ��������� ��������� ������ ���������� �� ���������� ������
        hasShownFourthAchievementIMG = PlayerPrefs.GetInt("hasShownFourthAchievementIMG", 0) == 1;

        // ³����� ������ ����������, ���� ���� ���� �������� �����
        if (hasShownFourthAchievementIMG)
        {
            achievementCompletedImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {

        if (FourthAchievmentCompleter.hasShownFourthAchievement && !hasShownFourthAchievementIMG)
        {
            // ���������� ����, �� ���������� ���� ��������
            hasShownFourthAchievementIMG = true;
            PlayerPrefs.SetInt("hasShownFourthAchievementIMG", hasShownFourthAchievementIMG ? 1 : 0);
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