using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnlargeString : MonoBehaviour {

	VideoPlayer vp;
	Vector3 scaleFrom;
	// Use this for initialization

	public int stratFrom;
    public int animationLength;
	public Vector3 scaleTo;
    public bool usingMidKey; 
	public Vector3 scaleTo2;
	float progress;
	Vector3 scale;
	Vector3 midkey;


	void Start () {
		vp = GetComponentInParent<VideoPlayer>();
		scaleFrom = transform.localScale;
		if(usingMidKey){
			midkey = scaleTo2;
		}
		else{
			midkey = (scaleFrom+scaleTo)/2;
		}
		//Debug.Log("enlarge start");
	}
	
	// Update is called once per frame
	void Update () {
		if(vp){
			progress = ((float)(vp.frame-stratFrom))/((float)animationLength);

			if (progress <0.5){
				scale = (Vector3.Lerp(scaleFrom,midkey,progress*2));
				//Debug.Log(progress);
			}else{
				scale = (Vector3.Lerp(midkey,scaleTo,progress*2-1));
				//Debug.Log(progress*2-1);
			}
	//		Debug.Log(scale);
			transform.localScale = scale ;
			//Debug.Log(" "+((float)vp.frame)/((float)vp.frameCount) +"; "+scale);

		}
	}
}
