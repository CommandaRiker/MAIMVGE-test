using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MovieTexture clip1 = (MovieTexture)renderer.material.mainTexture;
		if (Input.GetButtonDown ("Jump")) {

		
			if (clip1.isPlaying) {
				clip1.Pause();
			}
			else {
				clip1.Play();
			}
		}

		//renderer.material.mainTexture.Play();

	}
}
