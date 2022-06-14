using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimerManager : MonoBehaviour
{
    public TMP_Text timer;
    public int totalTime = 60;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Countdown", 1f, 1f);
    }

    void Countdown()
    {
        --totalTime;
        int min = Mathf.FloorToInt(totalTime / 60);
        int secs = Mathf.FloorToInt(totalTime - min * 60);
        timer.text = min + ":" + secs;
        if (totalTime == 0)
        {
            CancelInvoke("Countdown");
            print("GameOver");
        }
    }
}
