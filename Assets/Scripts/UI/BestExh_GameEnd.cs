using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestExh_GameEnd : MonoBehaviour
{
    public static float MaxBlowTimer_F_GO;
    private string MaxBlowTimer_S_GO;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Load();
        MaxBlowTimer_S_GO = MaxBlowTimer_F_GO.ToString();
        Text.text = MaxBlowTimer_S_GO;
    }
    private void Load()
    {
        MaxBlowTimer_F_GO = PlayerPrefs.GetFloat("MaxBlow");
    }
}
