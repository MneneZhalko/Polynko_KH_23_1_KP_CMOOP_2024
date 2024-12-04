using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAchievmentCompleter : MonoBehaviour
{
    private TheBraveMan theBraveMan; // ����� ��� ��������� ��������� �� TheBraveMan
    public static bool level1CompletedAchievement = false;
    public static bool hasShownThirdAchievement = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // ������ ��'��� TheBraveMan �� ����
        theBraveMan = FindObjectOfType<TheBraveMan>();
    }

    void Update()
    {
        level1CompletedAchievement = PlayerPrefs.GetInt("level1CompletedAchievement", 0) == 1;
        hasShownThirdAchievement = PlayerPrefs.GetInt("hasShownThirdAchievement", 0) == 1;

        if (theBraveMan != null && theBraveMan.lvlended && !level1CompletedAchievement)
        {
            // �������� �������� � PlayerPrefs
            level1CompletedAchievement = true;
            PlayerPrefs.SetInt("level1CompletedAchievement", level1CompletedAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }

        if (level1CompletedAchievement && !hasShownThirdAchievement)
        {
            // ���������� ����, �� ���������� ���� ��������
            hasShownThirdAchievement = true;
            PlayerPrefs.SetInt("hasShownThirdAchievement", hasShownThirdAchievement ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}