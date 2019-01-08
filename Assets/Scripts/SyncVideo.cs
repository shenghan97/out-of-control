using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SyncVideo : MonoBehaviour {
	
	public VideoPlayer vp;
	VideoPlayer myVp; // vp for the videoplayer to sync with, myVp for videoplayer to be synced(this vp)

	// Use this for initialization
	void Start () {
		myVp = GetComponent<VideoPlayer>();
		myVp.Play();

		//myVp.Pause();
	}
	
	// Update is called once per frame
	void Update () {
		//myVp.frame = vp.frame;
		//myVp.Play();
		//Debug.Log(vp.frame+" my:"+myVp.frame);
	}
}
