using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelScrirpr : MonoBehaviour
{
    public static int AngelQuantInScene;

    // Start is called before the first frame update
    void Start()
    {
        AngelQuantInScene = 1;
        StartCoroutine(DelAngel());
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.gameObject.CompareTag("Player"))
        {
            AngelQuantInScene = 0;
            Destroy(this.gameObject);
        }
    }
    IEnumerator DelAngel()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);

    }
}
