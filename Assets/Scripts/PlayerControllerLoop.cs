using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class PlayerControllerLoop : PlayerController {

    public Renderer rend;
    public RenderTexture loopTexture;

	void Start () {
		prepare = false;
		interactionFinished = false;
		
		foreach (VideoPlayer _vp in videoPlayersList)
		{
			try {_vp.Prepare();}
			catch (System.Exception e) {Debug.Log(e);}
		}
		if(endVideo!=null){
			endVideo.Prepare();
            endVideo.isLooping=true;
            Debug.Log("endvideo prepared");
			
		}
		//Application.targetFrameRate = (int)endVideo.frameRate;

		StartCoroutine(checkPlay());
	}
	
	IEnumerator checkPlay()
	{
		yield return new WaitUntil(()=>allPrepared(videoPlayersList));
		Debug.Log("PREPARED OK");
		prepare = true;
		foreach (VideoPlayer _vp in videoPlayersList)
		{
			try {
				_vp.Play();
				_vp.isLooping=false;
			}
			catch (System.Exception e) {Debug.Log(e);}
		}
				Debug.Log("Play OK");

		if(endVideo!=null){
			Debug.Log("play Co started");
			StartCoroutine(playEnd());

		}
	}

	IEnumerator playEnd(){
		yield return new WaitUntil(()=>(int)videoPlayersList[0].frame>(int)videoPlayersList[0].frameCount-1);
		Debug.Log("PlayerController:StartLoop");

		try {
            endVideo.Play();

            rend.material.SetTexture("_MainTex1",loopTexture);
            videoPlayersList[0].Stop();
            Destroy(videoPlayersList[0]);
            Debug.Log("background destroyed");

            }

		catch (System.Exception e) {Debug.Log(e);}
	}

/*	IEnumerator SyncWithFastest(){
		while (true)
		{
			if (syncedVideo.frame<2200){
			var frameList = from v in videoPlayersList select v.frame; 
			syncedVideo.frame = frameList.Max() + 15;
			Debug.Log(frameList.Max());
			}
			yield return new WaitForSeconds(1);;
		}

	}*/

	bool allPrepared(VideoPlayer[] _VPs){
		bool result = true;
		foreach (VideoPlayer _vp in _VPs)	
		{
			result &= _vp.isPrepared; 
		}
		
		return result;
	}

/*	public VideoPlayer vp1,vp2,vp3,vp4;

	public bool prepare;

	// Use this for initialization
	void Awake () {
		prepare = false;
		try
		{
			vp1.Prepare();
			vp2.Prepare();
			vp3.Prepare();
			vp4.Prepare();
		}
		catch (System.Exception e)
		{
			Debug.Log(e);
			
		}
		StartCoroutine(checkPlay());
	}
	
	IEnumerator checkPlay()
	{
		yield return new WaitUntil(()=>((vp1.isPrepared && vp2.isPrepared && vp3.isPrepared && (vp4 == null || vp4.isPrepared))));
		Debug.Log("PREPARED OK");
		prepare = true;
			try
			{
				Application.targetFrameRate = (int)vp1.frameRate;
				vp1.Play();
			}
			catch (System.Exception) {throw;}

			try {vp2.Play();}
			catch (System.Exception) {throw;}

			try {vp3.Play();}
			catch (System.Exception) {throw;}

			try {vp4.Play();}
			catch (System.Exception) {throw;}
	}

	// Update is called once per frame
	void Update () {
	

		}
	} */


} 
