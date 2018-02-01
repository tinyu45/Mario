using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour {

	public AudioSource MusicPlayer;
	public AudioSource SoundPlayer;
	public static AudioManger Instance; //单例

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	

	public void PlayMusic(string name){
		if (MusicPlayer.isPlaying == false) {
			AudioClip clip = Resources.Load<AudioClip> (name);
			MusicPlayer.clip = clip;
			MusicPlayer.Play ();
		}
	}


	public void StopMusic(){
		MusicPlayer.Stop ();
	}


	public void PlaySound(string name){
		AudioClip clip = Resources.Load<AudioClip> (name);
		SoundPlayer.PlayOneShot (clip);
	}

}
