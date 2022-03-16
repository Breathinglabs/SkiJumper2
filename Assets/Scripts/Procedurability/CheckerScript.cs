using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerScript : MonoBehaviour
{
    public GameObject Player;
    public Transform EndPos;
    public GameObject THISPlatform;
    public GameObject NEXTPlatformPrefab;
    public Transform AssetGen;
    public int MountainsToGen;
    public GameObject Mountain, Clouds;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    
        THISPlatform = transform.parent.gameObject;
        for (int MountainsGen = 0; MountainsGen < MountainsToGen; MountainsGen++)
        {
            Instantiate(Mountain, AssetGen.position, AssetGen.rotation);
        }

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
