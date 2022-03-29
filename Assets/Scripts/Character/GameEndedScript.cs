using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndedScript : MonoBehaviour
{
    public Animator CharaAnimator;
    public ParticleSystem SnowParticles;
    // Start is called before the first frame update
    void Start()
    {
        CharaAnimator.SetBool("GameEnded", true);
        SnowParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DeactParticles());
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Korone Rules");
            SnowParticles.Play();
        }

    }
    IEnumerator DeactParticles()
    {
        yield return new WaitForSeconds(3f);
        SnowParticles.Stop();
    }
}
