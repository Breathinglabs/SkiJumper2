using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_SFX_script : MonoBehaviour
{
    public AudioSource UFO_SFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            UFO_SFX.Play();
        }
    }
}
