using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class CharacterController : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public bool useMicro;
    public string SelDevice;
    public AudioMixerGroup MixerGroupMicro, MixerGroupMaster;
    public int SampleWindow = 512;

    public Rigidbody2D PlayerRigi;
    public float PlayerVeL;

    public float SkiJumpForce;

    public float AudioSignalMultiplier;
    public int ChangeMicro;
    public float levelMax = 0;
    public float levelMin = 1;
    public float Thresh = 0.5f;
    public bool IsBlowing = false;
    public float Sum;
    // Start is called before the first frame update
    void Start()
    {
     
       
        if (useMicro)
        {
            /* if the Microphone list it's bigger than 0 (no Microphones), select one, the AudioJack is mostly readed as 0, but try
                with diferent numbers!!
            */
            if (Microphone.devices.Length > 0)
            {
                SelDevice = Microphone.devices[ChangeMicro].ToString();
                audioSource.outputAudioMixerGroup = MixerGroupMicro;
                audioSource.clip = Microphone.Start(SelDevice, true, 20, AudioSettings.outputSampleRate);
                audioClip = audioSource.clip;
            }
            else
            {
                useMicro = false;
            }
        }
        if (!useMicro)
        {
            audioSource.outputAudioMixerGroup = MixerGroupMaster;
            audioSource.clip = audioClip;
        }
        

    }
    private void Update()
    {
       // PlayerRigi.AddForce (new Vector2 (PlayerVeL,PlayerRigi.velocity.y)*Time.deltaTime);
       // PlayerRigi.velocity = new Vector2(PlayerVeL, PlayerRigi.velocity.y);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRigi.velocity = new Vector2(PlayerVeL, PlayerRigi.velocity.y);
        audioSource.Play();
        LevelMaxMin();
        Sum = 0;
        if (LevelMaxMin() >= 0)
        {
                for (float SkiLevel = 0.001f; SkiLevel < LevelMaxMin(); SkiLevel++)
                {
                    SkiJumpForce = SkiLevel;
                    PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, SkiLevel));
             
                }
        }

    }

    float LevelMaxMin()
    {

        float[] waveData = new float[SampleWindow];
        int micPosition = Microphone.GetPosition(null) - (SampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        audioClip.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        levelMax = levelMax - 0.0015f*Time.deltaTime;

        levelMin = levelMin + 0.00015f*Time.deltaTime;
 

        for (int i = 0; i < SampleWindow; i++)
        {
           float wavePeak = Mathf.Abs(waveData[i]);
            Sum += wavePeak;

            if (wavePeak > levelMax)
            {
                levelMax = wavePeak;
            }
            if (wavePeak < levelMin)
            {
                 levelMin = wavePeak;
                Debug.Log(levelMin);
               
            }
        }
        Thresh = (levelMax - levelMin) / 2 + levelMin;
        if (levelMax > Thresh && IsBlowing == false)
        {
            IsBlowing = true;
        }
        if (levelMin < Thresh && IsBlowing == true)
        {
            IsBlowing = false;
        }

        return levelMax*AudioSignalMultiplier;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Angel")
        {

        }
        if (col.tag == "Rock")
        {
        
        }
    }

    IEnumerator FloorChecker()
    {
        yield return new WaitForSeconds(10f);
       // ImInIdle = false;
    }
    



}
  

