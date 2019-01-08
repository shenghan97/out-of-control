using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Text.RegularExpressions;





public class PlayerSelection2D : MonoBehaviour {

	[System.Serializable]
	public class VideoSet {
		public VideoClip Background;
		public VideoClip LoopBackgroud;
		public VideoClip Cup;
		}

	[System.Serializable]
	public class PlayerSet {
		public VideoPlayer Background;
		public VideoPlayer LoopBackgroud;
		public VideoPlayer Cup;
		}
	[Header("blue=0 red=1 yellow=2")]
	public VideoSet2[] videoSet;
	public PlayerSet playerSet;

    [System.Serializable]
    public class VideoSet2{
    public VideoSet[] videoOf;
    }
	string regex = "_(.*)STR";
	// Use this for initialization
	void Awake () {
		
		if(DataControl.data.ballon==DataControl.color.none){
			Debug.Log("data none: fallback to blue");
			playerSet.Background.clip = videoSet[0].videoOf[1].Background;
			if(videoSet[0].videoOf[1].LoopBackgroud)
			playerSet.LoopBackgroud.clip = videoSet[0].videoOf[1].LoopBackgroud;
			if(videoSet[0].videoOf[1].Cup)
			playerSet.Cup.clip = videoSet[0].videoOf[1].Cup;
		}else{
			Debug.Log("data fetchted:" + DataControl.data.ballon +" socks; " + DataControl.data.strin +" string");
			playerSet.Background.clip = videoSet[(int)DataControl.data.ballon].videoOf[(int)DataControl.data.strin].Background;
			if(videoSet[(int)DataControl.data.ballon].videoOf[(int)DataControl.data.strin].LoopBackgroud)
			playerSet.LoopBackgroud.clip = videoSet[(int)DataControl.data.ballon].videoOf[(int)DataControl.data.strin].LoopBackgroud;
			if(videoSet[(int)DataControl.data.ballon].videoOf[(int)DataControl.data.strin].Cup)
			playerSet.Cup.clip = videoSet[(int)DataControl.data.ballon].videoOf[(int)DataControl.data.strin].Cup;
		}

		//playerSet.LoopBackgroud.name = Regex.Match(playerSet.LoopBackgroud.clip.name,regex).Groups[1].Value;
		//playerSet.Cup.name = Regex.Match(playerSet.Cup.clip.name,regex).Groups[1].Value;
 
		//playerSet.LoopBackgroud.clip.name;

		//playerSet = videoSet[(int)DataControl.data.ballon];
		//videoSet[(int)DataControl.data.ballon]
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
