using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class stringOnFire : MonoBehaviour {
	[Header("Also include scene transiton")]
  	public int FIRE_FRAME = 2048;
    public  int END_FRAME = 1350;

	VideoPlayer vp;
	// Use this for initialization
	public PlayerController pc;
	public bool didFire;

    public BoxCollider2D[] boxColliders;


	void Start () {
		vp = GetComponent<VideoPlayer>();
		didFire =false;
		StartCoroutine(waitForBurst());
	}
	
	IEnumerator waitForBurst(){
		yield return new WaitUntil(()=> vp.frame>FIRE_FRAME);
		
        pc.interactionFinished = true;
		didFire = true;
		Debug.Log(gameObject.name + " on fire "+vp.frame);
		
        // Write to Data
        if(DataControl.data.strin==DataControl.color.none){
			DataControl.data.strin = (DataControl.color)System.Enum.Parse(typeof(DataControl.color),gameObject.name);
			Debug.Log("data written: "+ DataControl.data.strin);
		}
         

        // Pause Other Videos and Colliders and keep this video playing
		foreach (BoxCollider2D _bc in boxColliders)
		{
				_bc.enabled=false;
		}
		foreach (VideoPlayer _vp in pc.videoPlayersList)
		{
			//Debug.Log(_vp.name+"Go:"+gameObject.name);
            if(!(_vp.name.Equals(gameObject.name)||_vp.name.Equals("background"))){
				_vp.Pause();
				Destroy(_vp);
                Debug.Log(_vp+" destroyed");
			}
                /* ------- TO-DO --------
                There is a rare possibility that the two videos are syncronized due 
                to either the player not staring at either strings, or he/she managed to 
                stare at the both sides for exactly the same amount of time.
                */
        }	
    	vp.Play();

        // Fade transiton
        StartCoroutine(WaitToFade());

	}


    IEnumerator WaitToFade(){
        yield return new WaitUntil(()=> (vp.frame>END_FRAME)&&pc.interactionFinished);
		Initiate.Fade("cup",Color.black,1.0f);
    }
    
	// Update is called once per frame
	void Update () {

	}
}
