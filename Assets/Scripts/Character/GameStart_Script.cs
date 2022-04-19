using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart_Script : MonoBehaviour
{
    public Animator CharaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Game");
    }
}
