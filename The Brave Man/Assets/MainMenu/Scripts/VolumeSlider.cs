// Скрипт для роботи слайдеру зміни гучності у налаштуваннях
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = GlobalVolumeControl.globalVolume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        GlobalVolumeControl.globalVolume = value;
        GlobalVolumeControl.SaveVolume();
        GlobalVolumeControl.SetAllAudioSourcesVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("GlobalVolume", GlobalVolumeControl.globalVolume);
        PlayerPrefs.Save();
    }
}