using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDFPS : MonoBehaviour
{
    float accum = 0;
    int frames = 0;
    float timeleft;
    public float updateInterval = 0.5f;
    public GameObject textGui;

    void Start()
    {
        if (!textGui)
        {
            Debug.Log("UtilityFramesPerSecond needs a GUIText component!");
            enabled = false;
            return;
        }
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            float fps = accum / frames;
            string format = System.String.Format("{0:F2} FPS", fps);
            textGui.GetComponent<Text>().text = format;

            if (fps < 30)
            {
                textGui.GetComponent<Text>().color = Color.yellow;
            }
            else
            {
                if (fps < 10)
                {
                    textGui.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    textGui.GetComponent<Text>().color = Color.green;
                }
            }
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}