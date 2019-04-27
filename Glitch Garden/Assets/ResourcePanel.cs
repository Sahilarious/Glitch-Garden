using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanel : MonoBehaviour
{
	[SerializeField]
	GameObject fruitTreeButton;

	[SerializeField]
	GameObject[] projectileButtons;

	Dictionary<ProjectileTypes, GameObject> projectileButtonDict = new Dictionary<ProjectileTypes, GameObject>(); 

	void Start ()
	{
		fruitTreeButton.GetComponentInChildren<Text>().text = ResourcesManager.instance.currentTrees.ToString();

		foreach (GameObject button in projectileButtons)
		{
			ProjectileTypes projectileType = button.GetComponent<ResourceButton_Projectile>().projectileType;

			projectileButtonDict.Add(projectileType, button);
			button.GetComponentInChildren<Text>().text = ResourcesManager.instance.currentResourcesDict[projectileType].ToString();
		}
	}
	
	void Update ()
	{
		
	}

	public void UpdateAllResourceCounts()
	{
        Debug.Log("Update All Resource Counts");
        fruitTreeButton.GetComponentInChildren<Text>().text = ResourcesManager.instance.currentTrees.ToString();

        foreach (var button in projectileButtons) 
		{
			ProjectileTypes projectileType = button.GetComponent<ResourceButton_Projectile>().projectileType;

			UpdateResourceCount(button.GetComponentInChildren<Text>(), ResourcesManager.instance.currentResourcesDict[projectileType]);
		}
	}

	public void UpdateResourceCount(Text text, int count)
	{
		text.text = count.ToString();
	}
}
