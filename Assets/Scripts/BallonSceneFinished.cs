using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class BallonSceneFinished : MonoBehaviour {

	VideoPlayer vp;
	public PlayerController pc;
	// Use this for initialization
	void Start () {
		vp = GetComponent<VideoPlayer>();
		vp.loopPointReached += loadBurnin;
	}
	

	void loadBurnin(VideoPlayer _vp){
		try
		{foreach( VideoPlayer ballonVp in pc.videoPlayersList)
			ballonVp.Pause();}
		catch(System.Exception){}
		Initiate.Fade("burning",Color.black,2.0f);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
