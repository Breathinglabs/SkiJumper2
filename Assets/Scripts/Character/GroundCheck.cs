using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour
{
    public float OnTheGroundTimer;
    public bool AddTime;
    public float AngelLives;
    public ParticleSystem SnowParticles;
    public GameObject SnowPartShader;
    public static bool ImOnTheGround;
    public bool ExitedGround;
    public Transform AngelSpawnerPos;
    public GameObject Angel_GMOBJ;
    public bool ImOnTheGrounCorrection;
    public Animator MyAnim;
    // Start is called before the first frame update
    void Start()
    {
        SnowParticles.Stop();
        SnowPartShader.SetActive(false);
        ExitedGround = false;
        AngelLives = 0;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            ImOnTheGrounCorrection = false;
            SnowParticles.Play();
            SnowPartShader.SetActive(true);
            MyAnim.SetBool("OnTheGround", true);
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
            CharacterController.ImFallingDown = false;
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            SnowPartShader.SetActive(false);
            MyAnim.SetBool("OnTheGround", false);
            if (ImOnTheGrounCorrection == false)
            {
                StartCoroutine(GroundTimerResetCorrection());
            }
            if (ImOnTheGrounCorrection == true)
            {
                OnTheGroundTimer = 0;
            }
            ExitedGround = true;
            SnowParticles.Stop();
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
        yield return new WaitForSecondsRealtime(CharacterController.BlowTimer);
        ImOnTheGround = false;

    }
}
