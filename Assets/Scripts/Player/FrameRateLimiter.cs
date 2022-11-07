using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Visual Sync, sets the framerate of the game to your monitor.
        QualitySettings.vSyncCount = 1; //2 or 3 or 4

    }


}
