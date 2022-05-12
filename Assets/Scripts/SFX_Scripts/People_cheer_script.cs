using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People_cheer_script : MonoBehaviour
{
    public AudioSource PeopleCheering;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PeopleCheering.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PeopleCheering.Stop();
        }
    }
}
