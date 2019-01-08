using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayModeController : MonoBehaviour {

	// Use this for initialization
    private static bool created = false;

	public static bool gazeMode = false;

	public void startGame(){
		string name =  EventSystem.current.currentSelectedGameObject.name;
		Debug.Log(name+" being clicked");
		if(name.Equals("gaze"))
			gazeMode = true;
		else
			gazeMode = false;
		
		Initiate.Fade("balloons",Color.black,2.0f);

	}

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
