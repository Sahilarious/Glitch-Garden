using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemyType enemyType;

    [SerializeField]
    int speed = 5;

    [SerializeField]
    int health = 8;

    bool moveForward = false;

    void Start()
    {

    }

    void Update()
    {
        if (moveForward)
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
    }

    public void MoveForward()
    {
        moveForward = true;
    }

    public void Stop()
    {
        moveForward = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit!!");

        if (other.gameObject.tag == "projectile")
        {
            //Debug.Log("Hit!!");
            health -= other.gameObject.GetComponent<Projectile>().damage;
            other.gameObject.GetComponent<Projectile>().ResetProjectile();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
