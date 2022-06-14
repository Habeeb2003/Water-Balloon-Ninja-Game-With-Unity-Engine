using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private float sceneStartTime;
    // Start is called before the first frame update
    void Start()
    {
        //sceneStartTime = Time.unscaledTime;
        InvokeRepeating("CountTime", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountTime()
    {
        sceneStartTime = Time.unscaledTime;
        Debug.Log(sceneStartTime);
    }
}
