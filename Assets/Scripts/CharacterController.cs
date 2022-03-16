using System.Collections;
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

    public bool Up, Down;


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
        PlayerRigi.AddForce (new Vector2 (PlayerVeL,PlayerRigi.velocity.y)*Time.deltaTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        audioSource.Play();
        
   
        Debug.Log(LevelMax());
        if (LevelMax() >= 0)
        {
                for (float SkiLevel = 0.001f; SkiLevel < LevelMax(); SkiLevel++)
                {
                    SkiJumpForce = SkiLevel;
                    PlayerRigi.AddForce(new Vector2(PlayerRigi.velocity.x, SkiLevel));
             
                }
        }

    }

    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[SampleWindow];
        int micPosition = Microphone.GetPosition(null) - (SampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        audioClip.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        for (int i = 0; i < SampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
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
  

