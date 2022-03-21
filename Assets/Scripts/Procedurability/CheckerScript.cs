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
    public GameObject SpawnOBJ;
    public bool detected;
    public bool instantiated;
    // Start is called before the first frame update
    void Start()
    {
        instantiated = false;
        detected = false;
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
        if (detected == true)
        {
            Debug.Log("Ola");
           // Instantiate(NEXTPlatformPrefab, EndPos.transform.position, EndPos.transform.rotation);
            //StartCoroutine(DelPlatform());
            //detected = false;

        }
    }

    private void FixedUpdate()
    {
       // Vector3 upDir = new Vector2(transform.position.x, 1);
        RaycastHit2D hit = Physics2D.Raycast(SpawnOBJ.transform.position, transform.up*Mathf.Infinity);
        Debug.DrawRay(SpawnOBJ.transform.position, transform.up*Mathf.Infinity, Color.green);
        if (hit.collider.name == "GroundCheck")
        {
            Debug.Log("Target name: " + hit.collider.name);
            if (instantiated == false)
            {
                Instantiate(NEXTPlatformPrefab, EndPos.transform.position, EndPos.transform.rotation);
                instantiated = true;
            }
            StartCoroutine(DelPlatform());
        }

        //Debug DrawRay( , Vector2 upDir, Color color = color.white);



        if (hit.collider != null)
        {

        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D col)
    {
       
      if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(NEXTPlatformPrefab, EndPos.transform.position, EndPos.transform.rotation);
            StartCoroutine(DelPlatform());
        }
        
    }
    */
    IEnumerator DelHitRes()
    {
        yield return new WaitForSeconds(0.001f);

    }

    IEnumerator DelPlatform()
    {
        yield return new WaitForSeconds(DelTime);
        Destroy(THISPlatform);
    }
}
