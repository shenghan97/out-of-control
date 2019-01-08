using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Text.RegularExpressions;

public class PlayerSelection1D : MonoBehaviour {

	[System.Serializable]
	public struct VideoSet {
		public VideoClip Background;
		public VideoClip Video1;
		public VideoClip Video2;
		}

	[System.Serializable]
	public struct PlayerSet {
		public VideoPlayer Background;
		public VideoPlayer Video1;
		public VideoPlayer Video2;
		}
	[Header("blue=0 red=1 yellow=2")]
	public VideoSet[] videoSet;
	public PlayerSet playerSet;

	string regex = "_(.*)STR";
	// Use this for initialization
	void Awake () {
		
		if(DataControl.data.ballon==DataControl.color.none){
			Debug.Log("data none: fallback to blue");
			playerSet.Background.clip = videoSet[0].Background;
			playerSet.Video1.clip = videoSet[0].Video1;
			playerSet.Video2.clip = videoSet[0].Video2;
		}else{
			Debug.Log("data fetchted:" + DataControl.data.ballon +" socks");
			playerSet.Background.clip = videoSet[(int)DataControl.data.ballon].Background;
			playerSet.Video1.clip = videoSet[(int)DataControl.data.ballon].Video1;
			playerSet.Video2.clip = videoSet[(int)DataControl.data.ballon].Video2;
		}

		playerSet.Video1.name = Regex.Match(playerSet.Video1.clip.name,regex).Groups[1].Value;
		playerSet.Video2.name = Regex.Match(playerSet.Video2.clip.name,regex).Groups[1].Value;

		//playerSet.Video1.clip.name;

		//playerSet = videoSet[(int)DataControl.data.ballon];
		//videoSet[(int)DataControl.data.ballon]
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
