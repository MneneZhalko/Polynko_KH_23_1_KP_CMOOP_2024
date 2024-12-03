using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLvl2 : MonoBehaviour
{
    public Image BlockedLvl2;
    public Image Zapus2;

    void Start()
    {
        // ���������� ���� ������ ���������� � PlayerPrefs
        bool hasShownThirdAchievement = PlayerPrefs.GetInt("hasShownThirdAchievement", 0) == 1;

        // ���� ���������� ��� ���� ��������, �������� ����������
        if (hasShownThirdAchievement)
        {
            BlockedLvl2.gameObject.SetActive(false);
            Zapus2.gameObject.SetActive(true);
        }
        else
        {
            BlockedLvl2.gameObject.SetActive(true);
        }
    }
}