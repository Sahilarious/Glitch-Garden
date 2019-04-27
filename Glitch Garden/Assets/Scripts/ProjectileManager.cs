using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileTypes
{
    None,
    Tomato,
    Carrot,
    Corn
    //Potato,
    //Cabbage,
    //Cucumber,
    //Zucchini,
    //Onion,
    //Spinach,
    //Parsnip
}

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;

    [SerializeField]
    GameObject[] projectilePrefabs;

    Dictionary<ProjectileTypes, GameObject> projectilePrefabDict = new Dictionary<ProjectileTypes, GameObject>();
    public Dictionary<ProjectileTypes, List<GameObject>> projectilePoolsDict = new Dictionary<ProjectileTypes, List<GameObject>>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }

        CreateProjectilePools();
    }

    void Start()
    {
    }

    void CreateProjectilePools()
    {
        foreach (GameObject proj in projectilePrefabs)
        {
            projectilePrefabDict.Add(proj.GetComponent<Projectile>().pt, proj);
            List<GameObject> projectilePool = new List<GameObject>();
            for (int i = 0; i < 20; ++i)
            {
                GameObject newProj = Instantiate(proj, new Vector2(-1, -1), Quaternion.identity);
                projectilePool.Add(newProj);
            }

            projectilePoolsDict.Add(proj.GetComponent<Projectile>().pt, projectilePool);
        }
    }

    void ClearProjectilePools()
    {
        foreach (KeyValuePair<ProjectileTypes, List<GameObject>> projPool in projectilePoolsDict)
        {
            foreach(GameObject proj in projPool.Value)
            {
                Destroy(proj);
            }
        }
    }
}
