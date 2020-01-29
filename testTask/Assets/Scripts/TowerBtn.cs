using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject towerP;
    [SerializeField]
    private twPlace parentTwPlace;//a parent of the buy menu   

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (parentTwPlace.isEmpty)
            {
                parentTwPlace.PlaceTower(towerP);//calling tower creating function
                parentTwPlace.isEmpty = false; //tower has build and now the place unavailable
                parentTwPlace.towerPlaceBackground.transform.localScale = new Vector3(0, 1, 1);//closing buy menu
                parentTwPlace.isTriggered = false;
            }
        }
    }
}
