//Скрипт для зміни гучності всієї гри
using UnityEngine;
using UnityEngine.UI;


public class GlobalVolumeControl : MonoBehaviour
{
    public static float globalVolume = 1.0f;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("GlobalVolume"))
        {
            globalVolume = PlayerPrefs.GetFloat("GlobalVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("GlobalVolume", globalVolume);
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void SaveVolume()
    {
        PlayerPrefs.SetFloat("GlobalVolume", globalVolume);
        PlayerPrefs.Save();
    }

    public static void SetAllAudioSourcesVolume()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (var audioSource in allAudioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = globalVolume;
            }
        }
    }
}