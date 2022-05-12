using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1_SFX_script : MonoBehaviour
{
    public AudioSource Bird1_SFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Bird1_SFX.Play();
        }
    }
}
