using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twPlace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            PlaceTower();
        }
    }
    private void PlaceTower() {
        LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
        Instantiate(lm.TowerPrefab,transform.position, Quaternion.identity);
    }
}
