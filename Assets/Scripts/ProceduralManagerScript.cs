using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManagerScript : MonoBehaviour
{
    public Transform Player;
    public Transform levelpart_start;


    public Vector3 LastEndPlatform_Pos;
    // prefabs of the gameobjects you want to instantiate
    public Transform FloorPrefab;
    public GameObject FloorPrefab2;
    public GameObject AngelPrefab;

    private void Awake()
    {
        Transform lasLevelTransform;
        lasLevelTransform = SpawnLevelPart(levelpart_start.Find("EndPlatform").position);
        SpawnLevelPart();
        SpawnLevelPart();
    }
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLevelPart();
    }
    private void SpawnLevelPart()
    {
        Transform lastlevelpartTransform = SpawnLevelPart(LastEndPlatform_Pos);
        LastEndPlatform_Pos = lastlevelpartTransform.Find("EndPlatform").position;
    }
    private Transform SpawnLevelPart (Vector3 spawnPos)
    {
        Transform levelPartTransform = Instantiate (FloorPrefab, spawnPos, Quaternion.identity);
        return levelPartTransform;
    }
}
