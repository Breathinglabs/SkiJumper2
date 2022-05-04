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
    public GameObject Mountain, Clouds, Bird1, Bird2, Plane, ToyPlane, UFO;
    public int MountainsToGen, CloudsToGen;
    private int Bird1ToGen = 1, Bird2ToGen = 1, PlaneToGen = 1, PlaneToyToGen = 1, UFOToGen = 1;
    public float DelTime;
    public bool deleted;
    public GameObject SpawnOBJ;
    public bool detected;
    public bool instantiated;
    public int GenBird1, GenBird2, GenPlane, GenToyPlane, GenUFO;


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

    // Assets to gen
        // Sky Level 1
        if (Player.transform.position.y <= 25)
        {
            GenToyPlane = Random.Range(0, 5);
            if (GenToyPlane == 3)
            {
                var NewToyPlane = Instantiate(Bird1, AssetGen.parent.position, AssetGen.rotation);
                NewToyPlane.transform.parent = gameObject.transform;
            }
        }
        if (Player.transform.position.y <= 45)
        {
            GenBird1 = Random.Range(0, 2);
            if (GenBird1 == 1)
            {
                var NewBird1 = Instantiate(ToyPlane, AssetGen.parent.position, AssetGen.rotation);
                NewBird1.transform.parent = gameObject.transform;
            }
        }
        // Sky Level 2
        if (Player.transform.position.y <= 75)
        {
            GenPlane = Random.Range(0, 5);
            if (GenPlane <= 2)
            {
                var NewPlane = Instantiate(Plane, AssetGen.parent.position, AssetGen.rotation);
                NewPlane.transform.parent = gameObject.transform;
            }
        }
        if (Player.transform.position.y <= 100)
        {
            GenBird2 = Random.Range(0, 4);
            if (GenBird2 >= 2)
            {
                var NewBird2 = Instantiate(Bird2, AssetGen.parent.position, AssetGen.rotation);
                NewBird2.transform.parent = gameObject.transform;
            }
        }
        // Sky Level 3
        if (Player.transform.position.y <= 100)
        {
            GenUFO = Random.Range(0, 10);
            if (GenUFO <= 4)
            {
                var NewUFO = Instantiate(UFO, AssetGen.parent.position, AssetGen.rotation);
                NewUFO.transform.parent = gameObject.transform;
            }
        }

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

