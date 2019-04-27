using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class FruitTree : MonoBehaviour
{
    [SerializeField]
    GameObject resource;

    [SerializeField]
    Sprite treeSprite;

    [SerializeField]
    Sprite[] resourceSprites;

    Dictionary<ProjectileTypes, Sprite> spritesDict = new Dictionary<ProjectileTypes, Sprite>();


    private void Awake()
    {
        spritesDict.Add(ProjectileTypes.None, treeSprite);
        spritesDict.Add(ProjectileTypes.Tomato, resourceSprites[0]);
        spritesDict.Add(ProjectileTypes.Carrot, resourceSprites[1]);
        spritesDict.Add(ProjectileTypes.Corn, resourceSprites[2]);
    }

    void ChooseRandomResource()
	{
		ProjectileTypes[] projectileTypes = Enum.GetValues(typeof(ProjectileTypes)) as ProjectileTypes[];

        ProjectileTypes pt = projectileTypes[UnityEngine.Random.Range(0, projectileTypes.Length)];

        resource.GetComponent<SpriteRenderer>().sprite = spritesDict[pt];
        ResourcesManager.instance.AddResource(pt);
    }

}
