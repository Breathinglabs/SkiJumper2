using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2_SFX_script : MonoBehaviour
{
    public AudioSource Bird2_SFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Bird2_SFX.Play();
        }
    }
}
