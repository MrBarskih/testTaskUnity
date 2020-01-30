using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject towerP;
    [SerializeField]
    private twPlace parentTwPlace;//a parent of the buy menu child  

    private void OnMouseOver()
    {
        LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
        if (Input.GetMouseButtonDown(0)) {
            if (parentTwPlace.IsEmpty)
            {
                if (lm.Money >= towerP.GetComponent<Tower>().Price)
                {
                    parentTwPlace.PlaceTower(towerP);//calling tower creating function
                    parentTwPlace.towerPlaceBackground.transform.localScale = new Vector3(0, 1, 1);//closing buy menu
                    parentTwPlace.isTriggered = false;
                    lm.BuyTower(towerP.GetComponent<Tower>().Price);
                }
            }
            else {
                parentTwPlace.SellTower();//calling tower selling function
                parentTwPlace.towerSellBackground.transform.localScale = new Vector3(0, 1, 1);//closing sell menu
                parentTwPlace.isTriggered = false;
                lm.SellTower(parentTwPlace.CurrentTower.GetComponent<Tower>().Price);
            }
        }
    }
}
