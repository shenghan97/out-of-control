using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControll : MonoBehaviour {

    public Renderer rend;
	//public Rigidbody2D rb2d;
	public GameObject obj;
	public Camera camera;
	public float Speed;
	Vector2 position;
	Vector2 VectorInMap;
	Vector2 targetInWorld;
	Vector2 originInMap; 
	Vector2 originInWorld;


    void Start() {
        //rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/AlphaShade");
		//rend.material.shader.renderQueue
		Debug.Log(Tobii.Gaming.TobiiAPI.GetDisplayInfo());
    }
    
 		
	void FixedUpdate () {
		

		//Debug.Log(Tobii.Gaming.TobiiAPI.GetDisplayInfo());
		if(PlayModeController.gazeMode){
			targetInWorld =  GazePlotter.Smoothified;
			Speed = Speed*5;
//			Debug.Log("gaze mode");
		}
		else{
			targetInWorld =  camera.ScreenToWorldPoint(Input.mousePosition);
			Speed=Speed*2;
//			Debug.Log("mouse mode");
		}

		//targetInWorld =  GazePlotter.Smoothified;

		originInMap = rend.material.GetTextureOffset("_AlphaMap");  
		originInWorld = -new Vector2(originInMap.x * 16, originInMap.y * 9);
		//VectorInMap = -new Vector2(targetInWorld.x / 16, targetInWorld.y / 9);
		//Debug.Log(targetInMap);
		position = Vector2.MoveTowards(originInWorld, targetInWorld, Speed * Time.deltaTime );
		VectorInMap = -new Vector2(position.x / 16, position.y / 9);
		obj.transform.position = Vector2.MoveTowards(obj.transform.position, targetInWorld, Speed  * Time.deltaTime);
		rend.material.SetTextureOffset("_AlphaMap",VectorInMap);   

	}


	void Update()
	{
		if (Input.GetKeyDown("m")){
		PlayModeController.gazeMode = !PlayModeController.gazeMode;
		StartCoroutine(ChangeModeDuring.ShowOSD("Play Mode: "+(PlayModeController.gazeMode?"Gaze":"Mouse")));
		}
	}

}
