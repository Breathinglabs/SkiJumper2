using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MicrophoneScript : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public bool useMicro;
    public int ChangeMicro;
    public string SelDevice;
    public AudioMixerGroup MixerGroupMicro, MixerGroupMaster;
    public int SWin700 = 700;
    public int SWin64 = 64;

    public float AudioSignalMultiplier;
    public float levelMax = 0;
    public float levelMin = 1;
    public float Thresh = 0.5f;
    public static bool IsBlowing;
    public float Sum;
    public float Avrg;
    // Start is called before the first frame update
    void Start()
    {
        IsBlowing = false;
       
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
        IsBlowing = false;

    }
    private void Update()
    {
        SizeBig();
        audioSource.Play();
        Sum = 0;

    }


    public void SizeBig()
    {

        float[] BigWindow = new float[SWin700];
        int micPosition = Microphone.GetPosition(null) - (SWin700 + 1); // null means the first microphone
        audioClip.GetData(BigWindow, micPosition);

        // This get's the Max and Min level of the sample.
        levelMax = levelMax - 0.0015f*Time.deltaTime;
        levelMin = levelMin + 0.00015f*Time.deltaTime;
 

        for (int i = 0; i < SWin700; i++)
        {
         
            // Absolute
               float waveAbs = Mathf.Abs(BigWindow[i]);
             
            // Average
                Sum += waveAbs;
            //Debug.Log(Sum);
                Avrg = (Sum / SWin700)*10;
          //  Debug.Log(Avrg);
           
            if (waveAbs > levelMax)
            {
                levelMax = waveAbs;
            }
            if (waveAbs < levelMin)
            {
                 levelMin = waveAbs;
            }
        }
        Thresh = (levelMax - levelMin) / 2 + levelMin;
        if (Avrg > Thresh && IsBlowing== false)
        {
            Debug.Log("YES");
            IsBlowing = true;
        }
        if (Avrg < Thresh && IsBlowing == true)
        {
            Debug.Log("NO");
            IsBlowing = false;
        }

        
    }
    /*
    float SizeSmall()
    {

        float[] SmallWindow = new float[SWin64];
        float SWinAver = SmallWindow.Average();
        int micPosition = Microphone.GetPosition(null) - (SWin64 + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        audioClip.GetData(SmallWindow, micPosition);
        Average-= 0.0015f * Time.deltaTime;



        for (int i = 0; i < SWin64; i++)
        {
            float wavePeak = Mathf.Abs(SmallWindow[i]);
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

        return levelMax * AudioSignalMultiplier;
    }
    */

}
  

