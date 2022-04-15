using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Variance_UI: MonoBehaviour
{
    public static float VarianceUI_F;
    private string VarianceUI_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VarianceUI_S = VarianceUI_F.ToString();
        Text.text = VarianceUI_S;
    }
}
