using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Sript : MonoBehaviour
{
    public bool ImAMountain, ImACloud, ImAPerson, ImAStaelite;
    public Vector3 PosAfterGen;
    private SpriteRenderer Sprite;
    public int XPos;
    public int YPos;
    public int ZPos;
    public int LayerPos;
    public bool IveMoved;
    public GameObject checker;
    public CheckerScript checkerScript;
    public static int MountainNextLyrMskM = 0, CloudsNextLyrMskM = 0, 
        PersonsNextLyrMskM = 0, SatelliteNextLyrMskM = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        IveMoved = false;
        Sprite = GetComponent<SpriteRenderer>();
        if (ImAMountain)
        {
            XPos = Random.Range(0, 50);
            YPos = Random.Range(0, 5);
            ZPos = Random.Range(0, 0);
            MountainNextLyrMskM -= 1;
           // LayerPos = Random.Range(-10, 0);

        }
        if (ImACloud)
        {
            XPos = Random.Range(0, 20);
            YPos = Random.Range(7, 15);
            ZPos = Random.Range(0, 5);
            CloudsNextLyrMskM -= 1;
           // LayerPos = Random.Range(-10, 0);
        }
        if (ImAPerson)
        {
            XPos = Random.Range(0, 160);
            YPos = Random.Range(0, 5);
            ZPos = Random.Range(0, 2);
            LayerPos = Random.Range(-10, 0);
        }
        if (ImAStaelite)
        {
            XPos = Random.Range(0, 160);
            YPos = Random.Range(0, 5);
            ZPos = Random.Range(0, 2);
            LayerPos = Random.Range(-10, 0);
        }



        PosAfterGen = new Vector3(transform.position.x + XPos, YPos, ZPos);

    }

    // Update is called once per frame
    void Update()
    {
        if (!IveMoved)
        {
            transform.position = PosAfterGen;
            if (ImAMountain) Sprite.sortingOrder = MountainNextLyrMskM;
            if (ImACloud) Sprite.sortingOrder = CloudsNextLyrMskM;
            IveMoved = true;
          //  Sprite.sortingOrder = LayerPos;
    
        }
       
    }
    
}
