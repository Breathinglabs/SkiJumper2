using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSoundManager_UI : MonoBehaviour
{
    public Slider VolumeSlider;
    public GameObject MuteIcon;
    public static float Vol;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vol = AudioListener.volume;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;

        if (AudioListener.volume == 0)
        {
            MuteIcon.SetActive(true);
        }
        else
        {
            MuteIcon.SetActive(false);
        }

        Save();
    }

    private void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }
}
