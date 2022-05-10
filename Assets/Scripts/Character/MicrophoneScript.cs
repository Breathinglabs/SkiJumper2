/* 
Hi,
If you are going to use this same code in the future just make sure to delete all the code that makes reference to the UI, as you can guess it will be the responsible of the big majority of the issues 
that the game gives you when you copy and paste directly the code.

This code belongs to Breathing Labs in collaboration with Javier Molla Garcia (Gladark on GitHub), make sure to credit to both of us if used or modified it. 
Thanks.
 */

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
    public float waveAbs;
   public float lastAbs;
    public float avrg;
    public float Variance;

    public static float BlowTimer;
    public static float MaxBlow, MaxActBlow;
    public bool MuteAfterBlowBool;

    public bool Limit1, Limit2, Limit3;
    public int LastMicro;


    public bool BlowChecK;
    

    // Start is called before the first frame update
    void Start()
    {
        Load();
        IsBlowing = false;
        MuteAfterBlowBool = false;
        SelCheckMicro = ChangeMicro;
        Limit1 = false;
        Limit2 = false;
        
    }

    private void Update()
    {
        UseMicro();
        SizeBig(); //all our code: min, max, thr detection and avg comparison to thr which giver you boolean 1 or 0
        audioSource.Play(); //make the microphone work, this runs on everz frame because otherwise mic would stop working on each new update 
        if (MuteAfterBlowBool)
        {
            IsBlowing = false;
        }
        LevelMin_UI.LevelMinUI_F = levelMin;
        LevelMax_UI.LevelMaxUI_F = levelMax;
     //   Variance = 0; 
    }


    public void SizeBig()
    {
        int micPosition = Microphone.GetPosition(null) - (700 + 1); // null means the first microphone
        audioClip.GetData(DataArray, micPosition); //Take the microphone signal from the audio source

        // here we are decreasing max through time and increasing min in time
        levelMax = levelMax - 0.15f*Time.deltaTime;
        levelMin = levelMin + 0.015f*Time.deltaTime;
        //Debug.Log("The Level Min is" + levelMax);

        //Variance = 0;
      
        
        for (int i = 0; i < 699; i++)
        {
            
           ABSArray[i] = 100 * Mathf.Abs(DataArray[i]);
       //   Variance = Math.Abs(ABSArray[i] - ABSArray[i + 1]);
            
            
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
        if (avrg > Thresh+0.9f /*&& IsBlowing == false && Variance<=3f*/)
        {
            BlowTimer += Time.deltaTime;
            ActualBlowTimer_UI.BlowTimer_F = BlowTimer;
            if (BlowTimer > MaxBlow)
            {
                MaxBlow = BlowTimer;
                MaxBlow_UI.MaxBlowTimer_F = MaxBlow;
                Save();
            }
            if (BlowTimer > MaxActBlow)
            {
                MaxActBlow = BlowTimer;
                MaxActualBlowTimer_UI.MaxActBlowTimer_F = MaxActBlow;
            }

            StartCoroutine(MuteAfterBlow());
            BlowChecK = true;
            IsBlowing = true;
            
        }
        if (avrg < Thresh + 0.01f /*&& IsBlowing*/)
        {
            BlowTimer = 0;
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
  

      IEnumerator TakeLastMicro()
    {
        yield return new WaitForSeconds(0.01f);
        LastMicro = SelCheckMicro;

        yield return new WaitForSeconds(0.025f);
        SelCheckMicro = ChangeMicro;

    }
    IEnumerator MuteAfterBlow()
    {
        yield return new WaitForSeconds(BlowTimer);
        MuteAfterBlowBool = true;
        yield return new WaitForSeconds(1f);
        MuteAfterBlowBool = false;
        
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("MaxBlow", MaxBlow);
    }
    private void Load()
    {
        MaxBlow = PlayerPrefs.GetFloat("MaxBlow");
    }
}



