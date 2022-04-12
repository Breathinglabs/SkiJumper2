using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Threshold_UI : MonoBehaviour
{
    public static float ThresoldUI_F;
    private string ThresoldUI_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThresoldUI_S = ThresoldUI_F.ToString();
        Text.text = ThresoldUI_S;
    }
}
