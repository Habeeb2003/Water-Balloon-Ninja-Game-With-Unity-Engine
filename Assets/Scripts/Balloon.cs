using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public enum Special
    {
        AddMoreTime,
        SlowTime,
        Extralife,
        ManyBalloons,
        normal
    }
    public Special specialType;
    private float upwardVelocity;
    private Rigidbody2D rb;
    public bool IsActive { set; get; }
    
    public bool IsSlice { set; get; }

    public Sprite[] animSprite;
    private int spriteIndex;
    public SpriteRenderer sRenderer;
    private float lastSpriteUpdate;
    private float spriteUpdateDelta = 0.08f;

    private float rotationSpeed;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        if (this.gameObject.transform.position.y <= -11 && GameManager.Instance.gameMode == "LifePointsMode")
        {
            IsActive = false;
            if (IsSlice == false)
            {
                LifePointManager.instance.RemoveLP();
                LifePointManager.instance.lifePoint++;
            }
            FindObjectOfType<BalloonPool>().ReturnToPool(this);
        }
        if (IsSlice == true)
        {
            if (specialType == Special.Extralife)
            {
                FindObjectOfType<SpecialBalloons>().ExtraLife();
            }
            else if (specialType == Special.SlowTime)
            {
                FindObjectOfType<SpecialBalloons>().SlowTime();
            }
            if (spriteIndex != animSprite.Length - 1 && Time.time - lastSpriteUpdate > spriteUpdateDelta)
            {
                lastSpriteUpdate = Time.time;
                spriteIndex++;
                sRenderer.sprite = animSprite[spriteIndex];
                if (spriteIndex == animSprite.Length - 1)
                {
                    FindObjectOfType<BalloonPool>().ReturnToPool(this);
                    sRenderer.enabled = false;
                }
            }
        }
    }

    public void OnEnable()
    {
        IsSlice = false;
        sRenderer.enabled = true;
        spriteIndex = 0;
        sRenderer.sprite = animSprite[spriteIndex];
        if (transform.parent != null)
        {
            upwardVelocity = Random.Range(13.5f, 15);
            rb.AddForce(transform.parent.up * upwardVelocity, ForceMode2D.Impulse);
        }
        rotationSpeed = Random.Range(-180, 180);
    }
    public void Slice()
    {
        if (IsSlice == true)
        {
            print("Called slice function");
            return;
        }
        IsSlice = true;
        //FindObjectOfType<AudioManager>().Play("BalloonSlashed");
        //WaterSplash waterSpla = GameManager.Instance.GetWaterSplash();
        //float randomRota = Random.Range(0, 180);
        //waterSpla.gameObject.SetActive(true);
        //waterSpla.transform.position = transform.position;
        //waterSpla.transform.rotation = Quaternion.Euler(new Vector3(0, 0, randomRota));
        //double size = this.transform.localScale.x * 1 / 0.6 ;
        //waterSpla.alpha.a = 1;
        //waterSpla.InvokeRepeating("Fading", 0.1f, 0.1f);
        //ScoreManager.instance.score++;
        //ScoreManager.instance.ChangeScoreImage(this.gameObject.GetComponent<SpriteRenderer>().sprite);
        //if (ScoreManager.instance.score > ScoreManager.instance.highscore)
        //{
        //    ScoreManager.instance.highscore = ScoreManager.instance.score;
        //    PlayerPrefs.SetInt("Highscore", ScoreManager.instance.highscore);
        //    ScoreManager.instance.highscoreText.text = ScoreManager.instance.highscore.ToString();
            
        //}
    }
}
