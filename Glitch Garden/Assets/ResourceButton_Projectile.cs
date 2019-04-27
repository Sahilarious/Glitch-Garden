using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceButton_Projectile : MonoBehaviour
{
    [SerializeField]
    public ProjectileTypes projectileType;

    public void SelectResource()
    {
        ResourcesManager.instance.SelectProjectile(projectileType);
    }
}
