using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelStartPlat());
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    IEnumerator DelStartPlat()
    {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);

    }
}
