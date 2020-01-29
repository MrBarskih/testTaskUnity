using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class twPlace : MonoBehaviour
{
    public GameObject towerPlaceBackground;

    public bool isEmpty = true;//is there a tower?
    public bool isTriggered = false;//is there an opened buy menu?

    private void OnMouseOver()
    {
       
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0)) {//setting buy menu is visivble or invisible
                if (isEmpty)
                {
                    if (isTriggered)
                    {
                        towerPlaceBackground.transform.localScale = new Vector3(0, 1, 1);
                        isTriggered = false;
                    }
                    else {
                        towerPlaceBackground.transform.localScale = new Vector3(1, 1, 1);
                        isTriggered = true;
                    }
                }
                else {
                      
                    }
                }
            }
        
    }
    public void PlaceTower(GameObject chosenTower) {//creating a chosen tower in current towerPlace

        GameObject tower = (GameObject)Instantiate(chosenTower, transform.position, Quaternion.identity);
        //setting order in layer is equel 1
        tower.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //setting parent to creating tower
        tower.transform.SetParent(transform);
    }
}
