using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneUIController : MonoBehaviour
{

    public GameObject homePanel;
    public GameObject playPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        playPanel.SetActive(true);
        homePanel.SetActive(false);
    }

    public void BackToHome()
    {
        homePanel.SetActive(true);
        playPanel.SetActive(false);
    }

}
