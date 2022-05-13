using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlane_SFX_script : MonoBehaviour
{
    public AudioSource ToyPlane_SFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ToyPlane_SFX.Play();
        }
    }
}
