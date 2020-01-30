#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private int money;
    private int wave = 0;
    private int lives;

    public bool waveActive;
    private float spawnInterval = 1f;

    [SerializeField]
    private float[] waveDuration;
   
    public int Money {
        get => money;
        set {
            this.moneyTxt.text = "Money: " + value.ToString();
            this.money = value;
        }
    }

    public int Lives
    {
        get => lives;
        set
        {
            this.LivesTxt.text = "Lives: " + value.ToString();
            this.lives = value;
            if (this.lives <=0) {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
        }
    }

    [SerializeField]
    private TextMeshProUGUI moneyTxt = null;

    [SerializeField]
    private TextMeshProUGUI waveTxt;

    [SerializeField]
    private TextMeshProUGUI livesTxt;

    [SerializeField]
    private GameObject waveBtn;

    public Spawn Spawn;

    

    public ObjectPool Pool { get; set; }//getting entire massive of enemies
    public TextMeshProUGUI WaveTxt { get => waveTxt; private set => waveTxt = value; }
    public float[] WaveDuration { get => waveDuration; private set => waveDuration = value; }
    public TextMeshProUGUI LivesTxt { get => livesTxt; private set => livesTxt = value; }

    private void Awake()
    {
        Pool = GetComponent<ObjectPool>();
    }

    public void Start()
    {
        Money = 999;
        Lives = 100;
    }
    public void Update()
    {
        WaveManagment();
    }

    public void BuyTower(int towerPrice) {
        this.Money -= towerPrice;
    }

    public void SellTower(int towerPrice)
    {
        this.Money += towerPrice/2;
    }

    public void WaveManagment()
    {
        if (waveActive)
        {
            WaveDuration[wave - 1] -= Time.deltaTime;
            if (WaveDuration[wave - 1] <= 0)
            {
                if (wave == WaveDuration.Length)
                {
                    waveActive = false;
                }
                else
                {
                    StartWave();
                }
            }

            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0)
            {
                StartCoroutine(SpawnWave());
                spawnInterval = Random.Range(0.5f, 1f);
            }
        }
    }

    public void StartWave(){
        wave++;
        WaveTxt.text = "Wave: " + wave  + "/" + WaveDuration.Length;
        waveActive = true;
        waveBtn.SetActive(false);
    }

    private IEnumerator SpawnWave()//creating a random enemy from our pool massive
    {
        int monsterIndex = Random.Range(0, 4);

        string type = string.Empty;

        switch (monsterIndex)
        {
            case 0:
                type = "Enemy1";
                break;
            case 1:
                type = "Enemy2";
                break;
            case 2:
                type = "Enemy3";
                break;
            case 3:
                type = "Enemy4";
                break;
            default:
                break;
        }

        Enemies enemies = Pool.GetObject(type).GetComponent<Enemies>();
        enemies.Spawn();
        yield return new WaitForSeconds(2.5f);
    } 
}
