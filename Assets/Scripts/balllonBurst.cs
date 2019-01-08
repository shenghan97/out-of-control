using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class balllonBurst : MonoBehaviour {

  	public int BURST_FRAME = 2048;
	VideoPlayer vp;
	// Use this for initialization
	public PlayerController pc;
	public bool didBurst;

	public BoxCollider2D[] boxColliders;

	void Start () {
		vp = GetComponent<VideoPlayer>();
		didBurst =false;
		StartCoroutine(waitForBurst());
	}
	
	IEnumerator waitForBurst(){
		yield return new WaitUntil(()=> vp.frame>BURST_FRAME);
		pc.interactionFinished = true;
		didBurst = true;
		Debug.Log(gameObject.name + " burst "+vp.frame);
		if(DataControl.data.ballon==DataControl.color.none){
			DataControl.data.ballon = (DataControl.color)System.Enum.Parse(typeof(DataControl.color),gameObject.name);
			Debug.Log("data written: "+ DataControl.data.ballon);
		}

		foreach (VideoPlayer _vp in pc.videoPlayersList)
		{
			if(_vp.name!=gameObject.name){
				_vp.Pause();
				Destroy(_vp);
			}
		}	
		foreach (BoxCollider2D _bc in boxColliders)
		{
				_bc.enabled=false;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
