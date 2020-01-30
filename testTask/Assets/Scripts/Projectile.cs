using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemies target;

    public Enemies Target { get => target; set => target = value; }
    public int Damage { get => damage; set => damage = value; }

    [SerializeField]
    private int speed;

    [SerializeField]
    private int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            other.GetComponent<Enemies>().Health -= Damage;
            Destroy(gameObject);
        }
    }
}
