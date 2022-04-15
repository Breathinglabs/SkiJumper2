/* TODO: add speech detection in larger window and if true -> blow=1 && mute detetction for0.5 seconds*/

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
    public bool Conected;
    public int ChangeMicro;
    public int SelCheckMicro;
    public string SelDevice;
    public string LastSelDevice;
    public AudioMixerGroup MixerGroupMicro, MixerGroupMaster;
    public int SWin64 = 64;
    public float AudioSignalMultiplier;
    public float levelMax = 0.25f;
    public float levelMin = 1;
    public float Thresh = 0.5f;
    public static bool IsBlowing;
    public float[] ABSArray = new float[700];
    public float[] DataArray = new float[700];
    //public float[] AVRArray = new float[200];
    public float waveAbs;
   public float lastAbs;
    public float avrg;
    public float Variance;

    public bool Limit1, Limit2, Limit3;
    public int LastMicro;


    public bool BlowChecK;
    

    // Start is called before the first frame update
    void Start()
    {
        IsBlowing = false;
        SelCheckMicro = ChangeMicro;
        //ini_ChangeMicro = ChangeMicro;
        Limit1 = false;
        Limit2 = false;
        /*
         if (Conected)
         {
             /* if the Microphone list it's bigger than 0 (no Microphones), select one, the AudioJack is mostly readed as 0, but try
                 with diferent numbers!!

             if (Microphone.devices.Length > 0)
             {
                 SelDevice = Microphone.devices[ChangeMicro].ToString();
                 MicroUsing_UI.CurrentMicro_S = SelDevice;
                 audioSource.outputAudioMixerGroup = MixerGroupMicro;
                 audioSource.clip = Microphone.Start(SelDevice, true, 20, AudioSettings.outputSampleRate);
                 audioClip = audioSource.clip;
             }
             else
             {
                 Conected = false;
             }
         }
         if (!Conected)
         {
             audioSource.outputAudioMixerGroup = MixerGroupMaster;
             audioSource.clip = audioClip;
         }
         */
    }

    private void Update()
    {
        UseMicro();
        SizeBig(); //all our code: min, max, thr detection and avg comparison to thr which giver zou boolean 1 or 0
        audioSource.Play(); //make the microphone work, this runs on everz frame because otherwise mic would stop working on each new update 
        LevelMin_UI.LevelMinUI_F = levelMin;
        LevelMax_UI.LevelMaxUI_F = levelMax;
     //   Variance = 0; 



#if UNITY_EDITOR
        if (Input.GetButtonDown("Jump"))
                            {
                                IsBlowing = true;
                                BlowChecK = true;
                                Debug.Log("KeyBoard_Blow");
                            }
                            if (Input.GetButtonUp("Jump"))
                            {
                                IsBlowing = false;
                                BlowChecK = false;
                                Debug.Log("Released_KeyBoard_Blow");

                            }
                    #endif

    }


    public void SizeBig()
    {
        int micPosition = Microphone.GetPosition(null) - (700 + 1); // null means the first microphone
        audioClip.GetData(DataArray, micPosition); //Take the microphone signal from the audio source

        // here we are decreasing max through time and increasing min in time
        levelMax = levelMax - 0.15f*Time.deltaTime;
        levelMin = levelMin + 0.015f*Time.deltaTime;
        //Debug.Log("The Level Min is" + levelMax);

        Variance = 0;
        for (int i = 0; i < 699; i++)
        {
           ABSArray[i] = 100 * Mathf.Abs(DataArray[i]);
           Variance = Math.Abs(ABSArray[i] - ABSArray[i + 1]);

            
            if (ABSArray[i] > levelMax)
            {
                levelMax = ABSArray[i];
            }
            if (ABSArray[i] < levelMin)
            {
                levelMin = ABSArray[i];

            }
        }
        for (int i=0; i<255; i++)
        {
            avrg += ABSArray[699-i];
        }


        ///////////////
        avrg = avrg / 256;
        Thresh = (levelMax - levelMin) / 1000 + levelMin;
        if (avrg > Thresh+0.5f /*&& IsBlowing == false && Variance<=3f*/)
        {
            BlowChecK = true;
            IsBlowing = true;
            
        }
        if (avrg < Thresh + 0.01f /*&& IsBlowing*/)
        {
            BlowChecK = false;
            IsBlowing = false;
        }

        //float trueTresh = Thresh;
        Threshold_UI.ThresoldUI_F = Thresh;
        Average_UI.AvrgUI_F = avrg;
        Variance_UI.VarianceUI_F = Variance;

        //Debug.Log(trueTresh);
        
    }

    public void UseMicro()
    {
        MicroUsing_UI.CurrentMicro_S = SelDevice;
        LastMicro_UI.LastMicro_S = LastSelDevice;
        if (Conected)
        {
            if (SelCheckMicro != ChangeMicro && Limit1 == true && Limit2 == true)
            {
                Limit1 = false;
                Limit2 = false;
            }
            if (Microphone.devices.Length >= 0)
            {

                SelDevice = Microphone.devices[ChangeMicro].ToString();
                LastSelDevice = Microphone.devices[LastMicro].ToString();
                audioSource.outputAudioMixerGroup = MixerGroupMicro;
                if (Limit1 == false)
                { 
                    // Start getting micro signal
                    audioSource.clip = Microphone.Start(SelDevice, true, 20, AudioSettings.outputSampleRate);
                    audioClip = audioSource.clip;
                    Limit1 = true;
                }
                if (SelCheckMicro != ChangeMicro && Limit2 == false)
                {
                    StartCoroutine(TakeLastMicro());
                    Limit2 = true;
                }
            }
            else
            {
                Conected = false;
            }
        }
        if (!Conected)
        {
            audioSource.outputAudioMixerGroup = MixerGroupMaster;
            audioSource.clip = audioClip;
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

      IEnumerator TakeLastMicro()
    {
        yield return new WaitForSeconds(0.01f);
        LastMicro = SelCheckMicro;

        yield return new WaitForSeconds(0.025f);
        SelCheckMicro = ChangeMicro;

    }

}



