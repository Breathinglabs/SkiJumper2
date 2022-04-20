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
        mute = false;
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        lastvol = PlayerPrefs.GetFloat("musicVolume");
        ListenerSound.SetActive(false);
        ListenerMute.SetActive(true);
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
            ListenerMute.SetActive(false);
            ListenerSound.SetActive(true);
            if (limit1 == false)
            {
                StartCoroutine(Wait1());
                limit1 = true;
            }
        }

        if (mute == true)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
            mute = false;
            limit1 = false;
            ListenerSound.SetActive(false);
            ListenerMute.SetActive(true);
            
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("TittleScreen");
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.01f);
        mute = true;

    }
}
