using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeModeDuring : MonoBehaviour {


	static Text text;
	// Use this for initialization
	void Start () {
		text=GetComponent<Text>();
		text.enabled=false;
	}
	
	// Update is called once per frame


	public static IEnumerator ShowOSD(string s){
		text.text=s;
		text.color = new Color(1, 1, 1, 1);
		text.enabled=true;
		yield return new WaitForSeconds(1);
		
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime /0.25f)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(1,0,t));
			text.color = newColor;
			Debug.Log("t: "+t);
			yield return null;
		}
		text.enabled=false;
		text.text="";
	}
}
