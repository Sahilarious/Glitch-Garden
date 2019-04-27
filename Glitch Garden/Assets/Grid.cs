using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	[SerializeField]
	ResourcePanel resourcePanel;

	public void OnMouseDown()
	{
		ResourcesManager.instance.PlaceResource();
        resourcePanel.UpdateAllResourceCounts();
    }
}
