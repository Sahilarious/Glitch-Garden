using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ResourcesManager : MonoBehaviour
{
	public static ResourcesManager instance;

	[SerializeField]
	ResourcePanel resourcePanel;

	[SerializeField]
	GameObject fruitTree;

	[SerializeField]
	GameObject scarecrow;

	[SerializeField]
	GameObject selectedResource;

	ProjectileTypes selectedProjectile;

	Dictionary<Vector2, bool> grid = new Dictionary<Vector2, bool>();

	public int currentTrees = 5;

	public Dictionary<ProjectileTypes, int> currentResourcesDict = new Dictionary<ProjectileTypes, int>();

	//public Dictionary<ProjectileTypes, int> resourceImages = new Dictionary<ProjectileTypes, int>();

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

		InitializeGrid();
		InitializeResources();
	}

	void Start ()
	{
		
	}
	
	void Update ()
	{

	}

	public void SelectTree()
	{
		selectedResource = fruitTree;
	}

	public void SelectProjectile(ProjectileTypes projectileType)
	{
		selectedResource = scarecrow;

		selectedProjectile = projectileType;
	}

	public void DeselectResource()
	{
		selectedResource = null;
		selectedProjectile = ProjectileTypes.None;
	}

	void InitializeGrid()
	{
		for (int i = 1; i < 10; ++i)
		{
			for (int j = 1; j < 6; ++j)
			{
				Vector2 pos = new Vector2(i, j);
				grid.Add(pos, false);
			}
		}
	}

	public void InitializeResources()
	{
		var resourceTypes = Enum.GetValues(typeof(ProjectileTypes));
		foreach(ProjectileTypes type in resourceTypes)
		{
			if(type != ProjectileTypes.None)
			{
				currentResourcesDict.Add(type, 5);
			}
		}
	}


	public void PlaceResource()
	{
        Debug.Log("Mouse down");
        if (selectedResource != null)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));

            GameObject resource = Instantiate(selectedResource, new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0), Quaternion.identity);

            if (selectedProjectile != ProjectileTypes.None)
            {
                resource.GetComponent<Scarecrow>().projectileType = selectedProjectile;
                currentResourcesDict[selectedProjectile]--;

            }
            else
            {
                currentTrees--;
            }
        }

        selectedProjectile = ProjectileTypes.None;
        selectedResource = null;
    }

	public void AddResource(ProjectileTypes pt)
	{
		if(pt == ProjectileTypes.None)
		{
			currentTrees++;
		}
		else
		{
			currentResourcesDict[pt]++;
		}
		resourcePanel.UpdateAllResourceCounts();
	}
}
