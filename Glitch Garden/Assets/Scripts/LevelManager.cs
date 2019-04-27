using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
	[SerializeField]
	float levelLoadDelay = 3.0f;

	public static LevelManager instance;

	int currentSceneIndex = 0;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else
		{
			Destroy(this);
		}
	}

	void Start ()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		if (currentSceneIndex == 0)
		{
			StartCoroutine(LoadLevel(1));
		}
	}

	IEnumerator LoadLevel(int index)
	{
		yield return new WaitForSeconds(levelLoadDelay);

		SceneManager.LoadScene(index);
	}
	
}
