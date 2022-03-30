using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float OnTheGroundTimer;
    public bool AddTime;
    public float AngelLives;
    public ParticleSystem SnowParticles;
    public static bool ImOnTheGround;
    public bool ExitedGround;
    // Start is called before the first frame update
    void Start()
    {
        SnowParticles.Stop();
        ExitedGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AddTime)
        {
            OnTheGroundTimer = Time.time;
        }
        if (OnTheGroundTimer >= 10f)
        {
            if (AngelLives <= 3)
            {
                //Spawn Angel
            }
            else
            {
                //GameOver
            }

        }
        if (ExitedGround)
        {
           
            StartCoroutine(LockJump());
            ExitedGround = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            ImOnTheGround = true;
           AddTime = true;
           OnTheGroundTimer = 0;
            CharacterController.ImFallingDown = false;
            SnowParticles.Play();
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            ExitedGround = true;
            SnowParticles.Stop();
            AddTime = false;
        }
    }
    IEnumerator LockJump()
    {
        yield return new WaitForSeconds(CharacterController.BlowTimer);
        ImOnTheGround = false;

    }
}
