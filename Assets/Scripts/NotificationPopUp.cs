using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPopUp : MonoBehaviour
{
    public static NotificationPopUp instance;

    public GameObject popupGo;
    public Image comboImageLoad;

    public TMPro.TMP_Text comboText;
    private int slicePerSecs = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator ShowPopup()
    {
        popupGo.SetActive(true);
        comboText.text = slicePerSecs.ToString() + "x Combo";
        //comboImageLoad.rectTransform.rect.r
        yield return new WaitForSeconds(1f);
    }
}
