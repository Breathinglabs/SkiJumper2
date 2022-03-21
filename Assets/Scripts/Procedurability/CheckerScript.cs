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
    public float DelTime;
    public bool deleted;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        DelTime = 10f;
        THISPlatform = transform.parent.gameObject;
        for (int MountainsGen = 0; MountainsGen < MountainsToGen; MountainsGen++)
        {
           var NewMountain = Instantiate(Mountain, AssetGen.parent.position, AssetGen.rotation);
            NewMountain.transform.parent = gameObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 upDir = new Vector2(0, 1);
        RaycastHit2D hit = Physics2D.Raycast(AssetGen.transform.position, upDir);
        Debug.DrawRay(AssetGen.transform.position, upDir, Color.yellow);
        if (hit.collider == Player)
            {
            Debug.Log("Play a real Shen Megumin Ten Cents");
            }
        //Debug DrawRay( , Vector2 upDir, Color color = color.white);



        if (hit.collider != null)
        {

        }
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
        yield return new WaitForSeconds(DelTime);
        Destroy(THISPlatform);
    }
}
