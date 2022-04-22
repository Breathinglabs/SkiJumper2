using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndedScript : MonoBehaviour
{
    public Animator CharaAnimator;
    public ParticleSystem SnowParticles;
    public GameObject GameEndCanvas;
    private bool Limit;
    // Start is called before the first frame update
    void Start()
    {
        Limit = false;
        CharaAnimator.SetBool("GameEnded", true);
        GameEndCanvas.SetActive(false);
        SnowParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Limit == false)
        {
            StartCoroutine(DeactParticles());
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Nanashi Mumei Rules");
            SnowParticles.Play();
        }

    }
    IEnumerator DeactParticles()
    {
        yield return new WaitForSeconds(3f);
        SnowParticles.Stop();
        yield return new WaitForSeconds(2f);
        GameEndCanvas.SetActive(true);

    }


}
