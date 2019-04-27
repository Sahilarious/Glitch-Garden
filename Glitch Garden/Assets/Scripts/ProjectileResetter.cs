using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileResetter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            Debug.Log("Projectile reset");
            collision.GetComponent<Projectile>().ResetProjectile();
        }
    }
}
