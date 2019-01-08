using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour {

	public static Data data = new Data{ballon=color.none,strin=color.none,cup=color.none};
	// Use this for initialization
 	private static bool created = false;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

	public enum color:sbyte{
		none=-1,
		blue,
		red,
		yellow
	}
	public struct Data{
		public color ballon;
		public color strin;
		public color cup;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
