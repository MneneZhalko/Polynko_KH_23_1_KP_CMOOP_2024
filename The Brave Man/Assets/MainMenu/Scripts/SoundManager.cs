// ������, �� �������� �� ��'���, ��� ������ ������� ��� AudioSource �� ��'���
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