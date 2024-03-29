using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public bool mute;
    private bool limit1;
    public float lastvol;
    public GameObject ListenerMute, ListenerSound;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if (AudioListener.volume == 0)
        {
            mute = true;
            ListenerSound.SetActive(false);
            ListenerMute.SetActive(true);
        }
        else 
        {
            mute = false;
            ListenerSound.SetActive(true);
            ListenerMute.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteInGame()
    {
        if (mute == false)
        {
            AudioListener.volume = 0;
            ListenerMute.SetActive(true);
            ListenerSound.SetActive(false);
            if (limit1 == false)
            {
                StartCoroutine(Wait1());
                limit1 = true;
            }
        }

        if (mute == true)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
            if (AudioListener.volume ==0)
            {
                PlayerPrefs.SetFloat("musicVolume", 1f);
                AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
            }
            mute = false;
            limit1 = false;
            ListenerSound.SetActive(true);
            ListenerMute.SetActive(false);
            
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("TittleScreen");
    }
    public void BackToJump()
    {
        SceneManager.LoadScene("Game_Start");
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.01f);
        mute = true;

    }
}
