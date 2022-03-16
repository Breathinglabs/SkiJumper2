using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_script : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        transform.Translate(new Vector2 (Player.transform.position.x*0.25f, 0)*Time.deltaTime, Space.World);
    }
}
