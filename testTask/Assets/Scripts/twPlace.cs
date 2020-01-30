using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class twPlace : MonoBehaviour
{
    public GameObject towerPlaceBackground;//buy menu
    public GameObject towerSellBackground;//sell menu
    public GameObject currentTower;//installed tower

    private bool isEmpty = true;//is there a tower?
    public bool isTriggered = false;//is there an opened buy menu?

    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    public GameObject CurrentTower { get => currentTower; set => currentTower = value; }

    private void OnMouseOver()
    {
        LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0)) {//setting buy menu is visivble or invisible
                if (!lm.waveActive)//unavailable when wave is coming
                {
                    if (IsEmpty)
                    {
                        if (isTriggered)
                        {
                            towerPlaceBackground.transform.localScale = new Vector3(0, 1, 1);//invisible
                            isTriggered = false;
                        }
                        else
                        {
                            towerPlaceBackground.transform.localScale = new Vector3(1, 1, 1);//visible
                            isTriggered = true;
                        }
                    }
                    else
                    {
                        if (isTriggered)
                        {
                            towerSellBackground.transform.localScale = new Vector3(0, 1, 1);
                            isTriggered = false;
                        }
                        else
                        {
                            towerSellBackground.transform.localScale = new Vector3(1, 1, 1);
                            isTriggered = true;
                        }
                    }
                }
            }
        }
        
    }
    public void PlaceTower(GameObject chosenTower) {//creating a chosen tower in current towerPlace

        GameObject tower = (GameObject)Instantiate(chosenTower, transform.position, Quaternion.identity);
        CurrentTower = tower;
        IsEmpty = false; //tower has build and now the place unavailable
        //setting order in layer is equel 1
        CurrentTower.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //setting parent to creating tower
        CurrentTower.transform.SetParent(transform);
    }
    public void SellTower()//desctroy current tower
    {
        Destroy(CurrentTower);
        IsEmpty = true; //tower has destroied and now the place available
    }
}
