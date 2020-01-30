using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectPrefabs;//massive of all enemies

    public GameObject GetObject(string type) {//find an enemie by it's name
        for (int i = 0; i < objectPrefabs.Length; i++) {
            if (objectPrefabs[i].name == type) {
                GameObject newObject = Instantiate(objectPrefabs[i]);
                newObject.name = type;
                return newObject;
            }
        }
        return null;
    }
}
