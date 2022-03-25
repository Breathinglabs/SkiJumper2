using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour

{
    public Rigidbody2D PlayerRigi;
    public float PlayerVel, JumpQuant;
    private float Ini_PlayerVel, Ini_JumpQuant; //This varaiables are to store the value of the initial var.
    public GameObject AngelBehindYou;
    // Start is called before the first frame update
    void Start()
    {
        Ini_PlayerVel = PlayerVel;
        Ini_JumpQuant = JumpQuant;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        PlayerRigi.velocity = new Vector2(PlayerVel, PlayerRigi.velocity.y);
        if (MicrophoneScript.IsBlowing)
        {
            PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, JumpQuant));
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Angel"))
        {
            StartCoroutine(AngelAnim());
        }

    }
    IEnumerator AngelAnim()
    {
        PlayerVel = 0f;
        JumpQuant = 0f;
        AngelBehindYou.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, 500));
        yield return new WaitForSeconds(0.25f);
        PlayerVel = Ini_PlayerVel;
        JumpQuant = Ini_JumpQuant;
        AngelBehindYou.SetActive(false);


        // ImInIdle = false;
    }
    IEnumerator FloorChecker()
    {
        yield return new WaitForSeconds(10f);
        // ImInIdle = false;
    }
}
