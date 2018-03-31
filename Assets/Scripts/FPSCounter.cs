using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text text;
    public int frameBatchSize = 10;
    private int frameCounter = 0;
    float accumulatedTime = 0;
	// Update is called once per frame
	void Update ()
    {
        accumulatedTime += Time.deltaTime;
        ++frameCounter;
        if(frameCounter == frameBatchSize)
        {
            frameCounter = 0;
            float meanFrameTime = accumulatedTime / frameBatchSize;
            accumulatedTime = 0;
            text.text = (1/meanFrameTime).ToString() + "fps";
        }
	}
}
