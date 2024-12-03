// Скрипт, що додається на об'єкт, щоб змінити гучність усіх AudioSource на об'єкті
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = GlobalVolumeControl.globalVolume;
        }

        PlaySounds();
    }

    void PlaySounds()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
        }
    }
}