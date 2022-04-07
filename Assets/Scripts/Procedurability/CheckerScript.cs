using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerScript : MonoBehaviour
{
    public GameObject Player;
    public Transform EndPos;
    public GameObject THISPlatform;
    public GameObject NextPlatformPrefab1, NextPlatformPrefab2, NextPlatformPrefab3;
    public Transform AssetGen;
    public GameObject Mountain, Clouds;
    public int MountainsToGen, CloudsToGen;
    public float DelTime;
    public bool deleted;
    public GameObject SpawnOBJ;
    public bool detected;
    public bool instantiated;


    public int MountainsGenerated, CloudsGenerated;
    // Start is called before the first frame update
    void Start()
    {
        instantiated = false;
        detected = false;
        Player = GameObject.FindWithTag("Player");
        DelTime = 7.5f;
        THISPlatform = transform.parent.gameObject;

        /*

        if (Player.transform.position.y <= 25 && MountainsGenerated < MountainsToGen*2)
        {
            for (int MountainsGen = 0; MountainsGen < MountainsToGen; MountainsGen++)
            {
                var NewMountain = Instantiate(Mountain, AssetGen.parent.position, AssetGen.rotation);
                NewMountain.transform.parent = gameObject.transform;
                MountainsGenerated += 1;
            }
           
        }
        
        if (Player.transform.position.y <= 45 && CloudsGenerated < CloudsToGen * 2)
        {
            for (int CloudsGen = 0; CloudsGen < CloudsToGen; CloudsGen++)
            {
                var NewCloud = Instantiate(Clouds, AssetGen.parent.position, AssetGen.rotation);
                NewCloud.transform.parent = gameObject.transform;
                CloudsGenerated += 1;

            }
        }
            
        /*
        if (Player.transform.position.y >= 35)
        {
            for (int CloudsGen = 0; CloudsGen < CloudsToGen; CloudsGen++)
            {
                var NewMountain = Instantiate(Mountain, AssetGen.parent.position, AssetGen.rotation);
                NewMountain.transform.parent = gameObject.transform;
            }
        }
        */


    }

    // Update is called once per frame
    void Update()
    {
        if (detected == true)
        {
            Debug.Log("Ola");

        }
    }

    private void FixedUpdate()
    {
       // Vector3 upDir = new Vector2(transform.position.x, 1);
       /*
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
       */
    }

      
    
     void OnTriggerEnter2D(Collider2D col)
    {
       
      if (col.gameObject.CompareTag("Player"))
        {
            // 50 is the diference space between the EndPos position and the new platform pivot (which usually is on the center of the gameobject)
            Vector3 NewPlatPos = new Vector3(EndPos.transform.position.x + 5f, EndPos.position.y, EndPos.position.z);
            Instantiate(NextPlatformPrefab1, NewPlatPos, EndPos.transform.rotation);
            instantiated = true;
            StartCoroutine(DelPlatform());
        }
        
    }
    
    IEnumerator DelHitRes()
    {
        yield return new WaitForSeconds(0.001f);

    }

    IEnumerator DelPlatform()
    {
        yield return new WaitForSeconds(DelTime);
        
        if (MountainsGenerated > MountainsToGen)
        {
            MountainsGenerated -= MountainsToGen;
        }
        if (CloudsGenerated > CloudsToGen)
        {
            CloudsGenerated -= CloudsToGen;
        }
        Destroy(THISPlatform);
    }
}
