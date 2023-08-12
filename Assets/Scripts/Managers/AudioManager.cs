using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioSource playerJumpSound;

	// Singleton instance.
	public static AudioManager Instance = null;

	
	private void Awake()
	{
		
		if (Instance == null)
		{
			Instance = this;
		}
		
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set AudioManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

	
	public void PlaySound(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	public void PlayJumpSound(AudioClip clip)
    {
		playerJumpSound.clip = clip;
		playerJumpSound.Play();
    }

	
	

}