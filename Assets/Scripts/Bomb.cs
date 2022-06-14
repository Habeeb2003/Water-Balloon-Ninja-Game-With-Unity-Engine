using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float upwardVelocity;
    private Rigidbody2D rb;
    private bool isSlice;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (this.gameObject.transform.position.y <= -11)
        {
            FindObjectOfType<BombPool>().ReturnToQueue(this);
        }
        if (isSlice == true)
        {
            FindObjectOfType<BombPool>().ReturnToQueue(this);
            this.gameObject.GetComponent<Bomb>().enabled = false;
            if (GameManager.Instance.gameMode == "LifePointsMode")
            {
                LifePointManager.instance.RemoveLP();
                LifePointManager.instance.lifePoint++;
            }
        }
    }

    public void Slice()
    {
        if (isSlice == true)
        {
            return;
        }
        isSlice = true;
    }

    private void OnEnable()
    {
        this.gameObject.GetComponent<Bomb>().enabled = true;
        if (transform.parent != null)
        {
            upwardVelocity = Random.Range(13.5f, 15);
            rb.AddForce(transform.parent.up * upwardVelocity, ForceMode2D.Impulse);
        }
    }
}
