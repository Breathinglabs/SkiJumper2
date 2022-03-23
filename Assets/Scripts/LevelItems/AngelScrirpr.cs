using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelScrirpr : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D PlayerRigi;
    public float ElevatePlayer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerRigi = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.gameObject.CompareTag("Player"))
        {
            
            PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, PlayerRigi.velocity.y * ElevatePlayer));
            Debug.Log("UPPPPPPPPPPPPPPP");
            Destroy(this.gameObject);
        }
    }
}
