
/*
 Hi,
 This is the base code for reading the microphone input, that is how the Breathing+ works, this is a base file just with coments
  and explanations, PLS DON'T EDIT THIS CODE, copy and paste it in other script and let this for new people to understand how it works.
  Hope this could be useful.
    - Javier Mollá García
*/






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MicroBaseScript : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public bool useMicro;
    public string SelDevice;
    public AudioMixerGroup MixerGroupMicro, MixerGroupMaster;
    public int SampleWindow = 512;

    public Material FireMat;

    public float FireSLevel;
    public GameObject flareGMOBJ;
    public int ChangeMicro;
    public float FireDownSpeed;
    public bool Up, Down;

    // Start is called before the first frame update
    void Start()
    {
        FireSLevel = - 0.5f;
        FireMat = flareGMOBJ.GetComponent<MeshRenderer>().material;
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
        Up = true;


    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Play();
        FireMat.SetFloat("_Fire_Threeshold", FireSLevel);
        Debug.Log(LevelMax());
        if (LevelMax() >= 0)
        {
            if (Up && Down == false)
            {
                for (float FireLevel = 0.0000000000000000000000000000000001f; FireLevel < LevelMax(); FireLevel++)
                {
                    FireSLevel += Time.deltaTime * FireLevel;
                    if (FireSLevel >= 0)
                    {
                     Down = true;
                     Up = false;
                    }
                }
            }
            if (Down && Up == false)
            {
                FireSLevel -= Time.deltaTime * FireDownSpeed;
                if (FireSLevel <= -0.5f)
                {
                    Up = true;
                    Down = false;
                }
            }
            
            /*
            if (Down)
            {
                Up = false;
                FireSLevel += Time.deltaTime * 0.3f;
                if (FireSLevel <= -0.5f)
                {
                    Up = true;
                }

            }
            */
            

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
        return levelMax * 100;
    }



}
  

