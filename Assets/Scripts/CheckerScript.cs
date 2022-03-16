using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerScript : MonoBehaviour
{
    public GameObject Player;
    public Transform EndPos;
    public GameObject THISPlatform;
    public GameObject NEXTPlatformPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        //EndPos = GetComponentInChildren<Transform>();
        THISPlatform = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(NEXTPlatformPrefab, EndPos.transform.position, EndPos.transform.rotation);
            StartCoroutine(DelPlatform());
        }
    }

    IEnumerator DelPlatform()
    {
        yield return new WaitForSeconds(10f);
        Destroy(THISPlatform);
    }
}
