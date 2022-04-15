using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LastMicro_UI: MonoBehaviour
{
    public static string LastMicro_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = LastMicro_S;
    }
}
