using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation 
{
    public int touchId;
    public GameObject blade;

    public TouchLocation(int newTouchId, GameObject newBlade)
    {
        touchId = newTouchId;
        blade = newBlade;
    }
}
