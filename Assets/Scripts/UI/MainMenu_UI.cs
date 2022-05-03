using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public GameObject BaseMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;
    public GameObject BeforeYouPlay;

    public int BYP_DontShow;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("BeforeYouPlayAdvert"))
        {
            PlayerPrefs.SetInt("BeforeYouPlayAdvert", 0);
        }
        else
        {
            loadData();
        }
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if (BYP_DontShow == 0)
        {
            BeforeYouPlay.SetActive(true);
            BaseMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            CreditsMenu.SetActive(false);
        }
        if (BYP_DontShow == 1)
        {
            BeforeYouPlay.SetActive(false);
            BaseMenu.SetActive(true);
            OptionsMenu.SetActive(false);
            CreditsMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("Game_Start");
    }
    public void Settings()
    {
        OptionsMenu.SetActive(true);
        BaseMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }
    public void Credits()
    {
        CreditsMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        BaseMenu.SetActive(false);
    }
    public void ToMainMenu()
    {
        BaseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);

    }
    public void CloseBYP()
    {
        BeforeYouPlay.SetActive(false);
        BaseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        BYP_DontShow = 0;
        saveData();
    }

    public void DontShowBYP()
    {
        BeforeYouPlay.SetActive(false);
        BaseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        BYP_DontShow = 1;
        saveData();
    }

    public void ToDebugWindow()
    {
        SceneManager.LoadScene("Variables");
    }
    void saveData()
    {
        PlayerPrefs.SetInt("BeforeYouPlayAdvert", BYP_DontShow);
       
    }

    void loadData()
    {
        BYP_DontShow = PlayerPrefs.GetInt("BeforeYouPlayAdvert");
    }
}
