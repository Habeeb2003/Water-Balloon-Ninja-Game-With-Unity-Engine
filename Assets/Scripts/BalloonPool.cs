using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPool : MonoBehaviour
{
    [SerializeField]
    private List<Balloon> balloonPool;
    public Balloon[] balloonArr;

    void Start()
    {
        for (int i = 0; i < balloonArr.Length; i++)
        {
            AddToPool(i, 3);
        }
    }

    // Update is called once per frame
    public void AddToPool(int index, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Balloon b = Instantiate(balloonArr[index]);
            b.gameObject.SetActive(false);
            balloonPool.Add(b);
        }
    }
    public Balloon GetBalloon()
    {
        int randomRange = Random.Range(0, balloonPool.Count - 1);
        Balloon b = balloonPool[randomRange];
        balloonPool.Remove(balloonPool[randomRange]);
        float randomSize = Random.Range(0.6f, 0.8f);
        b.transform.localScale = new Vector3(randomSize, randomSize, 0);
        return b;
    }
    public void ReturnToPool( Balloon ballon)
    {
        ballon.transform.SetParent(null);
        ballon.gameObject.SetActive(false);
        balloonPool.Add(ballon);
    }
}
