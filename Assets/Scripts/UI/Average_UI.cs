using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Average_UI: MonoBehaviour
{
    public static float AvrgUI_F;
    private string AvrgUI_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AvrgUI_S = AvrgUI_F.ToString();
        Text.text = AvrgUI_S;
    }
}
