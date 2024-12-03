using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCircle : MonoBehaviour
{
    public static int savedHumans = 0;

    void OnCollisionEnter2D(Collision2D Stolknovenie)
    {
        if (Stolknovenie.gameObject.tag == "Human")
        {
            Destroy(Stolknovenie.gameObject);
            savedHumans++;
            gameObject.SetActive(false);
        }
    }

    public static int GetTotalSaved()
    {
        return savedHumans;
    }

    public static void ResetSavedHumans()
    {
        savedHumans = 0;
    }
}