using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float OnTheGroundTimer;
    public bool AddTime;
    public float AngelLives;
    public ParticleSystem SnowParticles;
    // Start is called before the first frame update
    void Start()
    {
        SnowParticles.Stop();
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
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
           AddTime = true;
           OnTheGroundTimer = 0;
            SnowParticles.Play();
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            SnowParticles.Stop();
            AddTime = false;
        }
    }
}
