using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MaxActualBlowTimer_UI: MonoBehaviour
{
    public static float MaxActBlowTimer_F;
    private string MaxActBlowTimer_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxActBlowTimer_S = MaxActBlowTimer_F.ToString();
        Text.text = MaxActBlowTimer_S;
    }
}
