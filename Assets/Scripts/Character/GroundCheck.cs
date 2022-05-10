using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour
{
    public float OnTheGroundTimer;
    public bool AddTime;
    public float AngelLives;
   // public ParticleSystem SnowParticles;
    public GameObject SnowPartShader;
    public GameObject FireShader;

    public static bool ImOnTheGround;
    public bool ExitedGround;
    public Transform AngelSpawnerPos;
    public GameObject Angel_GMOBJ;
    public bool ImOnTheGrounCorrection;
    public Animator MyAnim;
    // Start is called before the first frame update
    void Start()
    {
       // SnowParticles.Stop();
        SnowPartShader.SetActive(false);
        FireShader.SetActive(false);

        ExitedGround = false;
        AngelLives = 0;
    }

    private void Update()
    {
        if (ImOnTheGrounCorrection == true)
        {
            OnTheGroundTimer = 0;
            SnowPartShader.SetActive(false);
            MyAnim.SetBool("OnTheAir", true);
            ExitedGround = true;
        }
        if (CharacterController.ImFallingDown)
        {
            //MyAnim.SetBool("OnTheAir", false);
            MyAnim.SetBool("Falling", true);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            CharacterController.ImFallingDown = false;
            ImOnTheGrounCorrection = false;
            SnowPartShader.SetActive(true);
            MyAnim.SetBool("Falling", false);
            MyAnim.SetBool("OnTheAir", false);
            ImOnTheGround = true;
            OnTheGroundTimer += Time.deltaTime;
                if (OnTheGroundTimer >= 15f)
                {
                    if (AngelLives <= 3 && AngelScrirpr.AngelQuantInScene<1)
                    {
                        Instantiate(Angel_GMOBJ, AngelSpawnerPos.position, AngelSpawnerPos.rotation);
                        OnTheGroundTimer = 0;
                        AngelLives += 1;
                    }
                    if (AngelLives >=4)
                    {
                        SceneManager.LoadScene("Game_End");
                        Debug.Log("You Loose :'(");
                    }
                }
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            if (ImOnTheGrounCorrection == false)
            {
                StartCoroutine(GroundTimerResetCorrection());
                
            }
            if (ImOnTheGrounCorrection)
            {
                StartCoroutine(LockJump());
            }

            AddTime = false;
        }
    }
    IEnumerator GroundTimerResetCorrection()
    {
        yield return new WaitForSeconds(0.15f);
       ImOnTheGrounCorrection = true;

    }
     
    IEnumerator LockJump()
    {
        FireShader.SetActive(true);
        yield return new WaitForSecondsRealtime(MicrophoneScript.BlowTimer);
        // CharacterController.LastBlowTimer = CharacterController.BlowTimer;
        FireShader.SetActive(false);
        ImOnTheGround = false;
    }
}
