using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Scarecrow : MonoBehaviour
{
	[SerializeField]
	public ProjectileTypes projectileType = ProjectileTypes.Tomato;
	[SerializeField]
	GameObject projectileOrigin;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	public void ThrowProjectile()
	{
		int i = 0;
		while(ProjectileManager.instance.projectilePoolsDict[projectileType][i].activeSelf)
		{
			++i;
		}
		ProjectileManager.instance.projectilePoolsDict[projectileType][i].GetComponent<Projectile>().ThrowProjectile(projectileOrigin.transform.position);
	}

	void ChangeProjectile(ProjectileTypes pt)
	{
		projectileType = pt;
		switch (projectileType)
		{
			case ProjectileTypes.Tomato:
				break;
			case ProjectileTypes.Corn:
				break;
			case ProjectileTypes.Carrot:
				break;
			//case ProjectileTypes.Potato:
			//	break;
			//case ProjectileTypes.Cabbage:
			//	break;
			//case ProjectileTypes.Cucumber:
			//	break;
			//case ProjectileTypes.Zucchini:
			//	break;
			//case ProjectileTypes.Onion:
			//	break;
			//case ProjectileTypes.Spinach:
			//	break;
			//case ProjectileTypes.Parsnip:
			//	break;
		}
	}
}
