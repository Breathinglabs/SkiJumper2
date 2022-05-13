using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAfterBlow_Script : MonoBehaviour
{
    public static bool MuteAfterBlowVar;
    private string MaxBlowTimer_S;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (MuteAfterBlowVar)
        {
            Text.text = "true";
        }
        if (MuteAfterBlowVar == false)
        {
            Text.text = "false";
        }
    }
}
