using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainScript : MonoBehaviour
{
    public Vector3 PosAfterGen;
    private SpriteRenderer Sprite;
    public int XPos;
    public int YPos;
    public int ZPos;
    public int LayerPos;
    public bool IveMoved;
    public GameObject checker;
    public CheckerScript checkerScript;
    public static int NextLyrMskM = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        IveMoved = false;
        Sprite = GetComponent<SpriteRenderer>();
        XPos = Random.Range(0, 160);
        YPos = Random.Range(0, 5);
        ZPos = Random.Range(0, 2);
        NextLyrMskM -= 1;

        //checker = GameObject.Find("PlatformFloor");
        //transform.SetParent(checker.transform);
        LayerPos = Random.Range(-10, 0);
        PosAfterGen = new Vector3(transform.position.x + XPos, YPos, ZPos);
        //transform.localScale = new Vector3 (4f, 4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IveMoved)
        {
            transform.position = PosAfterGen;
            Sprite.sortingOrder = NextLyrMskM;
           IveMoved = true;
          //  Sprite.sortingOrder = LayerPos;
    
        }
       
    }
    
}
