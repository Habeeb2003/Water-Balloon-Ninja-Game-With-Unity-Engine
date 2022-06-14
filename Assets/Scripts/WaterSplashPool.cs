using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashPool : MonoBehaviour
{
    [SerializeField]
    private List<WaterSplash> waterSplashPool;
    public WaterSplash[] waterSplashArr;

    void Start()
    {
        for (int i = 0; i < waterSplashArr.Length; i++)
        {
            AddToPool(i, 3);
        }
    }

    // Update is called once per frame
    public void AddToPool(int index, int count)
    {
        for (int i = 0; i < count; i++)
        {
            WaterSplash b = Instantiate(waterSplashArr[index]);
            b.gameObject.SetActive(false);
            waterSplashPool.Add(b);
        }
    }
    public WaterSplash GetWaterSplash()
    {
        int randomRange = Random.Range(0, waterSplashPool.Count - 1);
        WaterSplash b = waterSplashPool[randomRange];
        waterSplashPool.Remove(waterSplashPool[randomRange]);
        return b;
    }
    public void ReturnToPool(WaterSplash waterSplash)
    {
        waterSplash.transform.SetParent(null);
        waterSplash.gameObject.SetActive(false);
        waterSplashPool.Add(waterSplash);
    }
}
