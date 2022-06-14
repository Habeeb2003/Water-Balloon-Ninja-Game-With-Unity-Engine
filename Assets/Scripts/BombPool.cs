using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    public Bomb bombPrefab;
    private Queue<Bomb> bombQueue = new Queue<Bomb>();

    // Start is called before the first frame update
    void Start()
    {
        AddToQueue(3);
    }

    public Bomb GetBomb()
    {
        if (bombQueue.Count == 0)
        {
            AddToQueue(1);
        }
        Bomb bb = bombQueue.Dequeue();
        return bb;
    }
    public void AddToQueue(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bomb b = Instantiate(bombPrefab);
            b.gameObject.SetActive(false);
            bombQueue.Enqueue(b);
        }

    }

    public void ReturnToQueue(Bomb bbb)
    {
        bbb.gameObject.SetActive(false);
        bombQueue.Enqueue(bbb);
    }
}
