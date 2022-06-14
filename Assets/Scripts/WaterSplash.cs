using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    [HideInInspector]
    public Color alpha;

    private void Awake()
    {
        alpha = GetComponent<SpriteRenderer>().color;
    }

    public void Fading()
    {
        if (alpha.a <= 0)
        {
            CancelInvoke("Fading");
            FindObjectOfType<WaterSplashPool>().ReturnToPool(this);
        }
        alpha.a -= 0.025f;
        this.GetComponent<SpriteRenderer>().color = alpha;
    }
}
