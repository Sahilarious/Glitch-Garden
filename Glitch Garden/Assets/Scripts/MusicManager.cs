using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
	public static MusicManager instance;

	[SerializeField]
	AudioClip[] audioClips;

	AudioSource audioSource;

	void Awake()
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
		audioSource = GetComponent<AudioSource>();

		if(SceneManager.GetActiveScene().buildIndex == 0)
		{
			audioSource.clip = audioClips[0];
		}

		if(audioSource.clip != null)
		{
			audioSource.Play();
		}
		else
		{
			Debug.LogError("There is no clip loaded in the audio source");
		}
	}
	

}
