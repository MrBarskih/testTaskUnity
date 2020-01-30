using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;

    public float speed;
    
    
    private Waypoints wpoints;

    [SerializeField]
    private int minReward;

    [SerializeField]
    private int maxReward;

    private int waypointIndex = 0;

    public int Health { get => health;
        set { 
            health = value;
            if (health <= 0) {
                LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
                lm.Money += Random.Range(minReward, maxReward); ;
                Destroy(gameObject);
            }
        }
        }

    void Start()
    {
        wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wpoints.waypoints[waypointIndex].position) < 0.1f) {
            if (waypointIndex < wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
        }
    }

    public void Spawn() {
        LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
        transform.position = lm.Spawn.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
        if (other.tag == "Castle") {
            lm.Lives -= damage;
            Destroy(gameObject);
        }
    }
}
