using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_script : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D Rigi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Rigi.velocity = new Vector2(CharacterController.PlayerVel, 0);
    }
}
