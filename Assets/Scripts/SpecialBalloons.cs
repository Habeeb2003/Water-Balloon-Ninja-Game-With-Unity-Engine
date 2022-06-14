using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialBalloons : MonoBehaviour
{
    public List<GameObject> lpModeSpecBalloons;
    public List<GameObject> countdownSpecBalloons;
    private int minSpawnPoint = 5;
    private int maxSpawnPoint = 10;
    private int randomInt;
    private bool haveSpawned = false;

    public GameObject notif;
    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(minSpawnPoint, maxSpawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.instance.score == randomInt && haveSpawned== false)
        {
            SpawnSpecialBalloon();
        }
    }

    void SpawnSpecialBalloon()
    {
        if (SceneManager.GetActiveScene().name == "LifePointsMode")
        {
            int randomIndex = Random.Range(0, lpModeSpecBalloons.Count);
            GameObject specialObj = Instantiate(lpModeSpecBalloons[randomIndex],GameManager.Instance.instPositons[Random.Range(0,GameManager.Instance.instPositons.Length-1)].transform);
            
        }
        haveSpawned = true;
    }

    public void ExtraLife()
    {
        notif.SetActive(true);
        notif.GetComponentInChildren<TMPro.TMP_Text>().text = "Extra Life";
        if (LifePointManager.instance.lifePoint != 0)
        {
            LifePointManager.instance.lifePoint--;
            LifePointManager.instance.AddLp();
        }

    }

    public void SlowTime()
    {
        notif.SetActive(true);
        notif.GetComponentInChildren<TMPro.TMP_Text>().text = "Slow Time";
        GameManager.Instance.startSlowTime = Time.unscaledTime;
        if (Time.timeScale == 1)
        {
            print("gotv");
            Time.timeScale = 0.6f;
        }
    }
}
