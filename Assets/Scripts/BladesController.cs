using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesController : MonoBehaviour
{
    public List<TouchLocation> touches = new List<TouchLocation>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    touches.Add(new TouchLocation(touch.fingerId, GetBlade(touch)));
                    TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == touch.fingerId);
                    thisTouch.blade.GetComponent<MyBlade>().StartCutting(touch);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == touch.fingerId);
                    thisTouch.blade.GetComponent<MyBlade>().StopCutting();
                    touches.RemoveAt(touches.IndexOf(thisTouch));
                    
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == touch.fingerId);
                    thisTouch.blade.transform.position = GetTouchPosition(touch.position);
                }
            }
        }
    }

    GameObject GetBlade(Touch t)
    {
        GameObject bla = FindObjectOfType<BladePool>().GetTrail();
        bla.name = "Blade" + t.fingerId;
        bla.transform.position = GetTouchPosition(t.position);
        return bla;
    }

    Vector2 GetTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector2(touchPosition.x, touchPosition.y));
    }
}
