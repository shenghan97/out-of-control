using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearTexture : MonoBehaviour {
	public RenderTexture[] rt;

	// Use this for initialization
	void Awake () {
		foreach (RenderTexture texture in rt)
		{
			RenderTexture.active = texture;
			GL.Begin(GL.TRIANGLES);
			GL.Clear(true, true, new Color(0,0,0,0));
			//GL.End();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
