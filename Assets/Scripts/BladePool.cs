using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladePool : MonoBehaviour
{
    public GameObject bladePrefab;
    public Queue<GameObject> bladeQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        AddToQueue(3);
    }

    public GameObject GetTrail()
    {
        if (bladeQueue.Count == 0)
        {
            AddToQueue(1);
        }
        GameObject bb = bladeQueue.Dequeue();
        bb.gameObject.SetActive(true);
        return bb;
    }
    public void AddToQueue(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject b = Instantiate(bladePrefab);
            b.gameObject.SetActive(false);
            bladeQueue.Enqueue(b);
        }

    }

    public void ReturnToQueue(GameObject bbb)
    {
        bbb.gameObject.SetActive(false);
        bladeQueue.Enqueue(bbb);
    }
}
