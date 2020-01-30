using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileType;

    [SerializeField]
    private int price;

    public int Price { get => price; set => price = value; }

    [SerializeField]
    private int damage;

    private Enemies target;

    private Queue<Enemies> enemies = new Queue<Enemies>();

    [SerializeField]
    private float range;

    [SerializeField]
    private float shootInterval;
    private float reload = 0;



    private void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = range;
    }
    void Update()
    {
        Attack();
    }

    private void Attack() {
        LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
        if (target == null && enemies.Count > 0) {
            target = enemies.Dequeue();
        }
        reload -= Time.deltaTime;
        if (reload <= 0)
        {
            if (target != null && target.isActiveAndEnabled)
            {
                GameObject projectile = (GameObject)Instantiate(projectileType, transform.position, Quaternion.identity);
                projectile.GetComponent<Projectile>().Target = target;
                projectile.GetComponent<Projectile>().Damage = damage;
            }
            reload = shootInterval;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy") {
            enemies.Enqueue(other.GetComponent<Enemies>());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            target = null;
        }
    }
}
