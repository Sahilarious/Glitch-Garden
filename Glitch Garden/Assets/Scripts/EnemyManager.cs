using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyType
{
	BanditRed,
	BanditYellow,
	BanditGreen
}

public class EnemyManager : MonoBehaviour
{
	[SerializeField]
	GameObject[] enemySpawners;

	[SerializeField]
	GameObject[] enemyPrefabs;

	Dictionary<EnemyType, GameObject> enemyPrefabsDict = new Dictionary<EnemyType, GameObject>();

	List<GameObject> spawnedEnemy = new List<GameObject>();

	float timer = 5;
	float currentTimer = 0;

	void Awake()
	{
		foreach(GameObject prefab in enemyPrefabs)
		{
			enemyPrefabsDict.Add(prefab.GetComponent<Enemy>().enemyType, prefab);
		}
	}

	void Start ()
	{

	}
	
	void Update ()
	{
		currentTimer += Time.deltaTime;
		if(currentTimer >= timer)
		{
			StartCoroutine(SpawnEnemy());
			currentTimer = 0;
		}
	}

	IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds(0);

		int spawnNum = UnityEngine.Random.Range(0, enemyPrefabs.Length);

		GameObject newEnemy = Instantiate(enemyPrefabs[spawnNum],
										  enemySpawners[spawnNum].transform.position,
										  Quaternion.identity);
		newEnemy.SetActive(true);

		spawnedEnemy.Add(newEnemy);
	}

	void ClearAllEnemies()
	{
		foreach(GameObject enemy in spawnedEnemy)
		{
			Destroy(enemy);
		}
	}
}
