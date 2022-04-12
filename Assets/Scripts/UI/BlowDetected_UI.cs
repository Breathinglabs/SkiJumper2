using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlowDetected_UI : MonoBehaviour
{
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MicrophoneScript.IsBlowing)
        {
            Text.text = "YES";
        }
        if (MicrophoneScript.IsBlowing == false)
        {
            Text.text = "NO";
        }
    }
}
