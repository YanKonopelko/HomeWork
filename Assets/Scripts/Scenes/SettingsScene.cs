using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScene : MonoBehaviour
{
    public Slider vfxSlider;
    public Slider musicSlider;
    private void Start()
    {
        vfxSlider.value = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : SoundManager.instance.volume;
        musicSlider.value = (PlayerPrefs.HasKey("MUSIC_VOLUME")) ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : MusicManager.instance.volume;
    }
    public void BackToMenu()
    {
        PlayerPrefs.Save();
        ScenesManager.instance.LoadScene("MainMenu");
    }

    public void SliderVFXChanged(Slider slider)
    {
        SoundManager.instance.ChangeVolume(slider.value);
        PlayerPrefs.SetFloat("VFX_VOLUME", slider.value);
    }

    public void SliderMusicChanged(Slider slider)
    {
        MusicManager.instance.ChangeVolume(slider.value);
        PlayerPrefs.SetFloat("MUSIC_VOLUME", slider.value);
    }
}
