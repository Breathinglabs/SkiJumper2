using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public GameObject BaseMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        BaseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
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

    public void ToDebugWindow()
    {
        SceneManager.LoadScene("Variables");
    }
}
