using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour

{
    public Rigidbody2D PlayerRigi;
    public float JumpQuant;
    public static float PlayerVel;
    private float Ini_PlayerVel, Ini_JumpQuant; //This varaiables are to store the value of the initial var.
    public GameObject AngelBehindYou;
    public static bool IReachedTheSky;
    public float SkyLevel, BlowTimerCheck;
    public bool IRTS_Check;
    public float Ypos;
    public static bool ImFallingDown;
    public bool ImFallingDown_Checker;
    private bool FallAfterReachingSky;
    public static float BlowTimer; 



    // Start is called before the first frame update
    void Start()
    {
        PlayerVel = 16f;
        Ini_PlayerVel = PlayerVel;
        Ini_JumpQuant = JumpQuant;
        ImFallingDown = false;
        IReachedTheSky = false;
        FallAfterReachingSky = false;

        //Initial Jump
        PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, 700));

    }

    // Update is called once per frame
    void Update()
    {
        BlowTimerCheck = BlowTimer;
        // Know if the pkayer is falling.
        ImFallingDown_Checker = ImFallingDown;
        if (Mathf.Abs(Ypos - transform.position.y) > 0.1F)
        {
            ImFallingDown = true;

        }
        Ypos = transform.position.y;
        if (ImFallingDown && IReachedTheSky)
        {
            StartCoroutine(FallTimerAfterReachSky());
        }


        IRTS_Check = IReachedTheSky;
        if (transform.position.y >= SkyLevel)
        {
            IReachedTheSky = true;
        }

        // Conditions to win
        if (ImFallingDown && IReachedTheSky && FallAfterReachingSky && transform.position.y <= 20)
        {
            SceneManager.LoadScene("Game_End");
            Debug.Log("You Win!!!!!!");
        }


        // In case of errors.
        if (transform.position.y <= -25)

        {
            Debug.Log("Fatal Error");
        }
      
       if (MicrophoneScript.IsBlowing == false)
        {
            BlowTimer = 0;
        }

    }
    private void FixedUpdate()
    {
        PlayerRigi.velocity = new Vector2(PlayerVel, PlayerRigi.velocity.y);
        if (MicrophoneScript.IsBlowing)
        {
            BlowTimer += Time.deltaTime;
            PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, JumpQuant));
            /*
            if (GroundCheck.ImOnTheGround)
            {
                PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, JumpQuant));
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Angel"))
        {
            StartCoroutine(AngelAnim());
        }
    }

    IEnumerator FallTimerAfterReachSky()
    {
        yield return new WaitForSeconds(4.5f);
        FallAfterReachingSky = true;
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
    }
  
    /*
        Hi,
        If this message is for the new people someone that is encharged yo update the game or whatever, 
        Sorry if the code it's kinda... a dissaster :(
     
    */
}
