using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBlade : MonoBehaviour
{
    // stores touch id of the touch controlling the blade
    public int touchId;

    private Vector3 lastMousePos;
    private Collider2D[] balloonCols;
    private Collider2D[] bombCols;
    private const float requiredSliceForce = 500f;

    public float minCuttingVelocity = .001f;

    private bool isCutting = false;

    private int sliceCombo = 0;
    private float lastSliceTime;

    public GameObject comboFloatingText;
    
    // Start is called before the first frame update
    void Start()
    {
        balloonCols = new Collider2D[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Touch t = new Touch();
        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == touchId)
            {
                t = touch;
            }
        }
      
        Vector3 pos = Camera.main.ScreenToWorldPoint(t.position);

        pos.z = -1;
        this.transform.position = pos;
        Collider2D[] thisFrameBalloon = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Balloon"));
        if ((new Vector3(t.position.x, t.position.y, lastMousePos.z) - lastMousePos).magnitude * Time.deltaTime > minCuttingVelocity)
        {
            foreach (Collider2D item in thisFrameBalloon)
            {
                for (int i = 0; i < balloonCols.Length; i++)
                {
                    if (item == balloonCols[i] && item.GetComponent<Balloon>().IsSlice == false)
                    {
                        item.GetComponent<Balloon>().Slice();
                        print("sliced");
                        //  check if slicedcombo is 0
                        if (sliceCombo == 0)
                        {
                            //  set lastSlice to currentTime
                            
                            sliceCombo++;   // increase sliceCombo by 1
                            print(Time.time - lastSliceTime);
                        }
                        else    //  if not 👆
                        {
                            print(Time.time - lastSliceTime);
                            if (sliceCombo >= 3)
                            {
                                StartCoroutine(showCombo());
                            }
                            //if (sliceCombo >= 3 && Time.time - lastSliceTime > 0.05)
                            //{
                            //    Debug.Log("slice combo is " + sliceCombo);
                            //    int point = 0;
                            //    if (sliceCombo == 3)
                            //        point = 10;
                            //    else if (sliceCombo == 4)
                            //        point = 15;
                            //    else if (sliceCombo >= 5)
                            //        point = 20;
                            //    Instantiate(comboFloatingText, this.transform.position, Quaternion.identity);
                            //    comboFloatingText.transform.GetChild(0).GetChild(0) .GetComponent<TextMesh>().text = sliceCombo.ToString() + " x combo";
                            //    comboFloatingText.transform.GetChild(0).GetChild(1).GetComponent<TextMesh>().text = "+" + point.ToString();
                            //}
                            //  check if the difference from the lastTime to the current time is not more than 0.1
                            if (Time.time - lastSliceTime <= 0.2)
                            {
                                sliceCombo++;
                            }
                            else
                            {
                                sliceCombo = 0;
                            }
                        }
                        lastSliceTime = Time.time;
                    }
                }
            }
        }
        Collider2D[] thisFrameBomb = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bomb"));
        if ((new Vector3(t.position.x, t.position.y, lastMousePos.z) - lastMousePos).magnitude * Time.deltaTime > minCuttingVelocity)
        {
            foreach (Collider2D item in thisFrameBomb)
            {
                for (int i = 0; i < bombCols.Length; i++)
                {
                    if (item == bombCols[i])
                    {
                        item.GetComponent<Bomb>().Slice();
                    }
                }
            }
        }
        lastMousePos = t.position;

        balloonCols = thisFrameBalloon;
        bombCols = thisFrameBomb;
    }
    public void StartCutting(Touch t)
    {
        isCutting = true;
        lastMousePos = t.position;
        touchId = t.fingerId;
    }

    public void StopCutting()
    {
        isCutting = false;
        FindObjectOfType<BladePool>().ReturnToQueue(this.gameObject);
    }

    private void OnEnable()
    {
        sliceCombo = 0;
    }

    IEnumerator showCombo()
    {
        int bCombo = sliceCombo;
        yield return new WaitForSeconds(0.2f);
        int aCombo = sliceCombo;
        if ( aCombo < bCombo )
        {
            Debug.Log("slice combo is " + sliceCombo);
            int point = 0;
            if (sliceCombo == 3)
                point = 10;
            else if (sliceCombo == 4)
                point = 15;
            else if (sliceCombo >= 5)
                point = 20;
            Instantiate(comboFloatingText, this.transform.position, Quaternion.identity);
            comboFloatingText.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = sliceCombo.ToString() + " x combo";
            comboFloatingText.transform.GetChild(0).GetChild(1).GetComponent<TextMesh>().text = "+" + point.ToString();
        }
        else if ( aCombo > )
        {

        }
    }
}
