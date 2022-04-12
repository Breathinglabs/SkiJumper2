using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelMax_UI: MonoBehaviour
{
    public static float LevelMaxUI_F;
    private string LevelMinUI_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelMinUI_S = LevelMaxUI_F.ToString();
        Text.text = LevelMinUI_S;
    }
}
