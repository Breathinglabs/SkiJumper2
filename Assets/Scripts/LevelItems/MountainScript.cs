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
    // Start is called before the first frame update
    void Start()
    {
        IveMoved = false;
        Sprite = GetComponent<SpriteRenderer>();
        XPos = Random.Range(0, 50);
        YPos = Random.Range(0, 5);
        ZPos = Random.Range(0, 3);
        LayerPos = Random.Range(-10, 0);
        PosAfterGen = new Vector3(transform.position.x + XPos, YPos, ZPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IveMoved)
        {
            transform.position = PosAfterGen;
            IveMoved = true;
            Sprite.sortingOrder = LayerPos;
    
        }
       
    }
    
}
