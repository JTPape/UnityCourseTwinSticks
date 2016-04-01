using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Horizontal: " + CrossPlatformInputManager.GetAxis ("Horizontal"));
		Debug.Log ("Vertical: " + CrossPlatformInputManager.GetAxis ("Vertical"));
	}
}
