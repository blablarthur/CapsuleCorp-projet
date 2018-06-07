using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Soundcharrette : NetworkBehaviour {
	public AudioSource source;
	public AudioClip clip;
	private bool isPlayed;
	void OnTriggerEnter(Collider other)
	{
		source = GetComponent<AudioSource> ();
		source.Play ();
	}
	// Use this for initialization
	/*public void Awake () {
		source = GetComponent<AudioSource> ();
		isPlayed = false;
	}
	void OnCollisionEnter(Collision dataFromCollision)
	{
		if (dataFromCollision.gameObject.tag == "Player")
		{
			source.Play ();
		}
	} */
	// 
	
	// Update is called once per frame
	/*public void OnTriggerEnter (Collider other) {
		if (!isPlayed) {
			source.Play ();
			isPlayed = true;
		}
	}*/
}
