using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MaxBlow_UI : MonoBehaviour
{
    public static float MaxBlowTimer_F;
    private string MaxBlowTimer_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxBlowTimer_S = MaxBlowTimer_F.ToString();
        Text.text = MaxBlowTimer_S;
    }

}
