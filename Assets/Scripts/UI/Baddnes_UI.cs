using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Baddnes_UI: MonoBehaviour
{
    public static float BadnessUI_F;
    private string BadnessUI_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BadnessUI_S = BadnessUI_F.ToString();
        Text.text = BadnessUI_S;
    }
}
