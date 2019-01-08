using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class ColliderController : MonoBehaviour {
	BoxCollider2D bc;
	// Use this for initialization
	public VideoPlayer vp;
	public PlayerController pc;

	public int startPoint = 0;
	void Start () {
		GetComponent<SpriteRenderer>().color = new Color(255,0,0,0);
		bc = GetComponent<BoxCollider2D>();
		bc.enabled = false;
		StartCoroutine(checkEnable());	//check if players are prepared and enable the collider, 
										//to prevent the players replay after prepare  
	}
	
	IEnumerator checkEnable()
	{
		yield return new WaitUntil(()=>((pc.prepare == true)&&(vp.frame>startPoint)));
		bc.enabled = true;

	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
//		Debug.Log(other.gameObject.name+" Enter :"+Time.time);
		vp.Pause();

	}
	void OnTriggerExit2D(Collider2D other)
	{
//		Debug.Log(other.gameObject.name+" EXIT : "+Time.time);
		vp.Play();
	}
}
