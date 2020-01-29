using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int money;
    public int Money { 
        get => money;
        set { 
            this.moneyTxt.text = "Money: " + value.ToString(); 
            this.money = value; 
        }
    }

    [SerializeField]
    private TextMeshProUGUI moneyTxt;

 

    public void Start()
    {
        Money = 999;
    }
    public void BuyTower() {
        
    }

}
