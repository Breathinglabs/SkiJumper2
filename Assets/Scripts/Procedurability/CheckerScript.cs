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
    public GameObject Bird1, Bird2, UFO, Plane, Toy_Plane;
    public int GenBird1, GenBird2, GenUFO, GenPlane, GenToyPlane;
    public float DelTime;
    public bool deleted;
    public GameObject SpawnOBJ;
    public bool detected;


    public int MountainsGenerated, CloudsGenerated;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        DelTime = 7.5f;
        THISPlatform = transform.parent.gameObject;

        // Level1

        if (Player.transform.position.y <= 25)
        {
            GenToyPlane = Random.Range(0, 6);
            if (GenToyPlane > 4)
            {
                Vector3 ToyPlanePos = new Vector3 (AssetGen.parent.position.x, AssetGen.parent.position.y+7, AssetGen.parent.position.z);
                var NewToyPlane = Instantiate(Toy_Plane,ToyPlanePos, AssetGen.rotation);
                Toy_Plane.transform.parent = gameObject.transform;
            }
        }

        if (Player.transform.position.y <= 35)
        {
            GenBird1 = Random.Range(0, 2);
           if (GenBird1 == 1)
            {
                Vector3 Bird1Pos = new Vector3(AssetGen.parent.position.x, AssetGen.parent.position.y + 15, AssetGen.parent.position.z);
                var NewBird1 = Instantiate(Bird1, Bird1Pos, AssetGen.rotation);
                NewBird1.transform.parent = gameObject.transform;
            }
        }

        //Level 2

        if (Player.transform.position.y >=50 && Player.transform.position.y <=100)
        {
            GenBird2 = Random.Range(0, 10);
            if (GenBird2 >= 8)
            {
                Vector3 Bird2Pos = new Vector3(AssetGen.parent.position.x, AssetGen.parent.position.y + 60, AssetGen.parent.position.z);
                var NewBird2 = Instantiate(Bird2, Bird2Pos, AssetGen.rotation);
                NewBird2.transform.parent = gameObject.transform;
            }
        }

        if (Player.transform.position.y >= 75 && Player.transform.position.y <= 125)
        {
            GenPlane = Random.Range(0, 10);
            if (GenPlane >= 6)
            {
                Vector3 PlanePos = new Vector3(AssetGen.parent.position.x, AssetGen.parent.position.y + 90, AssetGen.parent.position.z);
                var NewPlane = Instantiate(Plane, PlanePos, AssetGen.rotation);
                Plane.transform.parent = gameObject.transform;
            }
        }

        //Level3
           if (Player.transform.position.y >= 200)
        {
            GenUFO = Random.Range(0, 10);
            if (GenUFO >= 9)
            {
                Vector3 UFOPos = new Vector3(AssetGen.parent.position.x, AssetGen.parent.position.y + 200, AssetGen.parent.position.z);
                var NewUFO = Instantiate(UFO, UFOPos, AssetGen.rotation);
                UFO.transform.parent = gameObject.transform;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
    }
     void OnTriggerEnter2D(Collider2D col)
    {
       
      if (col.gameObject.CompareTag("Player"))
        {
            // 50 is the diference space between the EndPos position and the new platform pivot (which usually is on the center of the gameobject)
            Vector3 NewPlatPos = new Vector3(EndPos.transform.position.x + 5f, EndPos.position.y, EndPos.position.z);
            Instantiate(NextPlatformPrefab1, NewPlatPos, EndPos.transform.rotation);
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
        Destroy(THISPlatform);
    }
}
