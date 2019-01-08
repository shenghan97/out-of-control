using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Quit : MonoBehaviour {

	VideoPlayer vp;
	// Use this for initialization
	public PlayerController pc;
	void Start () {
		vp = GetComponent<VideoPlayer>();
		if(pc.prepare)
			vp.loopPointReached += quitNow;
	}
	
	void quitNow(VideoPlayer _vp){
		Debug.Log("quiting");
		Application.Quit();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
