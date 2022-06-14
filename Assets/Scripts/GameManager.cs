using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; } 
    public GameObject[] instPositons;
    public Balloon balloon;

    [HideInInspector]
    public string gameMode;

    public WaterSplashPool waterSplashPool;

    private float launchRate = 0.3f;
    private float launchTime = 2f;
    private float firstLaunchTime = 1.5f;
    private int maxNumOfBalloon = 5;
    private int minNumOfBalloon = 2;
    private int randomNumOfBalloon;
    private int numOfBalloon = 0;
    bool startSpawn = false;

    private float maxBombLaunchTime = 5f;
    private float minBombLaunchTime = 2.5f;
    private float randomBombLaunchTime;
    bool bombSpawn = false;
    int numOfBomb = 0;

    public GameObject pauseUiMenu;

    // variable for slowTime
    public float startSlowTime = 0;
    private float endSlowTime = 5f;

    private void Awake()
    {
        Instance = this;
        gameMode = SceneManager.GetActiveScene().name;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startSlowTime != 0 && Time.unscaledTime - startSlowTime > endSlowTime)
        {
            print("change");
            Time.timeScale = 1;
            startSlowTime = 0;
        }

        if (bombSpawn == false)
        {
            bombSpawn = true;
            StartCoroutine("SpawnBomb");
        }
        if (numOfBalloon >= randomNumOfBalloon && startSpawn == true)
        {
            CancelInvoke("LaunchBalloon");
            firstLaunchTime = 0;
            numOfBalloon = 0;
            startSpawn = false;
        }
        firstLaunchTime += Time.deltaTime;
        if (firstLaunchTime >= launchTime)
        {
            if (startSpawn == true)
                return;

            if (startSpawn == false)
            {
                randomNumOfBalloon = Random.Range(minNumOfBalloon, maxNumOfBalloon);
                InvokeRepeating("LaunchBalloon", 1f, launchRate);
                startSpawn = true;
            }
        }
    }
    void BombSequence()
    {
        Invoke("LaunchBomb", randomBombLaunchTime);
    }
    void LaunchBalloon()
    {
        Balloon b = FindObjectOfType<BalloonPool>().GetBalloon();
        int randomIndex = Random.Range(0, instPositons.Length - 1);
        b.transform.SetParent(instPositons[randomIndex].transform);
        b.transform.position = instPositons[randomIndex].transform.position;
        b.gameObject.SetActive(true);
        numOfBalloon++;
    }
    void LaunchBomb()
    {
        Bomb b = FindObjectOfType<BombPool>().GetBomb();
        int randomIndex = Random.Range(0, instPositons.Length - 1);
        b.transform.SetParent(instPositons[randomIndex].transform);
        b.transform.position = instPositons[randomIndex].transform.position;
        b.gameObject.SetActive(true);
        //numOfBomb++;
    }

    IEnumerator SpawnBomb()
    {
        randomBombLaunchTime = Random.Range(minBombLaunchTime, maxBombLaunchTime);
        yield return new WaitForSeconds(randomBombLaunchTime);
        float howManyTimes = Random.Range(1, 3);
        for (int i = 0; i < howManyTimes; i++)
        {
            yield return new WaitForSeconds(0.5f);
            LaunchBomb();
        }
        bombSpawn = false;
    }
    public WaterSplash GetWaterSplash()
    {
        return waterSplashPool.GetWaterSplash();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseUiMenu.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseUiMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
