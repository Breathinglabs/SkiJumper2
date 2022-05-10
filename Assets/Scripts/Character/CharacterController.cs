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
    public float SkyLevel, BlowTimerCheck, lastBlowCheck;
    public bool IRTS_Check;
    public float Ypos;
    public static bool ImFallingDown;
    public bool ImFallingDown_Checker;
    private bool FallAfterReachingSky;
    public static float BlowTimer;
    public float MaxBlowTimer;
    public float ActMaxBlow;
    public SpriteRenderer PlayerSprite;
    public Material PlayerMaterial;
    public bool MuteAfterFall;



    // Start is called before the first frame update
    void Start()
    {
        PlayerVel = 16f;
        Ini_PlayerVel = PlayerVel;
        Ini_JumpQuant = JumpQuant;
        ImFallingDown = false;
        IReachedTheSky = false;
        PlayerMaterial = PlayerSprite.material;
        PlayerMaterial.SetInt("_Wings", 0);
        FallAfterReachingSky = false;
        ActMaxBlow = 0;
        Load();
        MaxBlow_UI.MaxBlowTimer_F = MaxBlowTimer;
        AngelBehindYou.SetActive(false);
        MuteAfterFall = false;

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
            if (ImFallingDown==true)
            {
               
                PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, -JumpQuant));
            }

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
        if (MuteAfterFall)
        {
            MicrophoneScript.IsBlowing = false;
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
            ActualBlowTimer_UI.BlowTimer_F = BlowTimer;

        }

    }
    private void FixedUpdate()
    {
        PlayerRigi.velocity = new Vector2(PlayerVel, PlayerRigi.velocity.y);
        if (MicrophoneScript.IsBlowing && GroundCheck.ImOnTheGround== true)
        {
            //StartCoroutine(ForceToGoDow());
            BlowTimer += Time.deltaTime;
            ActualBlowTimer_UI.BlowTimer_F = BlowTimer;
            if (BlowTimer > ActMaxBlow)
            {
                ActMaxBlow = BlowTimer;
                MaxActualBlowTimer_UI.MaxActBlowTimer_F = ActMaxBlow;
            }
         
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
    
    IEnumerator FallTimerAfterReachSky()
    {
        yield return new WaitForSeconds(4.5f);
        FallAfterReachingSky = true;
    }
    IEnumerator AngelAnim()
    {
        PlayerVel =PlayerVel/2f;
        JumpQuant = 0f;
        PlayerMaterial.SetInt("_Wings", 1);
        AngelBehindYou.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, 800f));
        yield return new WaitForSeconds(0.45f);
        PlayerVel = Ini_PlayerVel;
        PlayerMaterial.SetInt("_Wings", 0);
        JumpQuant = Ini_JumpQuant;
        AngelBehindYou.SetActive(false);
    }
    private void Load()
    {
        MaxBlowTimer = PlayerPrefs.GetFloat("MaxBlow");
    }

    /*
        Hi,
        If this message is for the new people someone that is encharged yo update the game or whatever, 
        Sorry if the code it's kinda... a dissaster :(
     
    */
}
