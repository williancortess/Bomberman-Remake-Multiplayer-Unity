using UnityEngine;
using System.Collections;

public class DestructionEf : MonoBehaviour {
	float auxTime = 0.0f;
	float timeDestruction = 1.0f;
//	AudioSource playerAudio;
//	public AudioClip kaboom;
	// Use this for initialization
	void Start () {
//		playerAudio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		auxTime += Time.deltaTime;
		if (auxTime > timeDestruction) {
		//	playerAudio.Play ();
			//Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
