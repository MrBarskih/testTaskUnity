using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public float speed;
    private Waypoints wpoints;

    private int waypointIndex = 0;

    void Start()
    {
        wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wpoints.waypoints[waypointIndex].position) < 0.1f) {
            if (waypointIndex < wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else {
                Destroy(gameObject);
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
           
        }
    }
}
