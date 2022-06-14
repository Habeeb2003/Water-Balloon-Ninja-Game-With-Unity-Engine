using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointManager : MonoBehaviour
{
    public static LifePointManager instance { get; set; }
    public Image[] lifePoints;
    public int lifePoint;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RemoveLP()
    {
        lifePoints[lifePoint].gameObject.SetActive(false);
        if (lifePoint == lifePoints.Length-1)
        {
            Time.timeScale = 0;
            print("done");
        }
    }
    public void AddLp()
    {
        lifePoints[lifePoint].gameObject.SetActive(true);
    }
}
