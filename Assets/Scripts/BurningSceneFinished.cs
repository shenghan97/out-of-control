using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class BurningSceneFinished : MonoBehaviour {

	public static VideoPlayer vp;
	public PlayerController pc;
	// Use this for initialization
    public const int END_FRAME = 1350;

	void Start () {
        StartCoroutine(WaitToFade());
	}
	
    IEnumerator WaitToFade(){
        yield return new WaitUntil(()=> (vp.frame>END_FRAME)&&pc.interactionFinished);
		Initiate.Fade("burning",Color.black,2.0f);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
