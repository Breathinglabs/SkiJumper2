using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActualBlowTimer_UI: MonoBehaviour
{
    public static float BlowTimer_F;
    private string BlowTimer_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BlowTimer_S = BlowTimer_F.ToString();
        Text.text = BlowTimer_S;
    }
}
