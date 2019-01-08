using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class drinking : MonoBehaviour {
	[Header("Also include scene transiton")]
  	//public int FIRE_FRAME = 2048;
    //public  int END_FRAME = 1350;

	VideoPlayer vp;
	// Use this for initialization
	public PlayerController pc;
	public bool didEmptied;

    public AudioSource bgm;

    public BoxCollider2D[] boxColliders;


	void Start () {
		vp = GetComponent<VideoPlayer>();
		didEmptied =false;
		StartCoroutine(waitForBurst());
	}
	
	IEnumerator waitForBurst(){
		yield return new WaitUntil(()=> pc.prepare&&(int)vp.frame>(int)vp.frameCount-200);
		
        pc.interactionFinished = true;
		didEmptied = true;
		Debug.Log(gameObject.name + " emptied "+vp.frame);
		
        // Pause  Colliders
		 foreach (BoxCollider2D _bc in boxColliders)
		{
				_bc.enabled=false;
                Debug.Log("bc disabled");
		}
		
     	vp.Play();

        // Fade transiton
        vp.loopPointReached += Fade;

	}


    void Fade(VideoPlayer vp){
       // yield return new WaitUntil(()=> (vp.fram=fr)&&pc.interactionFinished);
		StartCoroutine(WaitAndFade());
    }
    
    IEnumerator WaitAndFade(){
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AudioFadeOut.FadeOut(bgm,0.25f));
        Initiate.Fade("end",Color.black,2.0f);
    }
  

	// Update is called once per frame
	void Update () {

	}
}
