using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	public GUIStyle firstStyle;
	public GUIStyle secondStyle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box (new Rect (Screen.width / 5.64f - 48.85f, Screen.height / 6.6f, 200, 100), "30 Seconds To Launch",secondStyle);
		if (GUI.Button (new Rect (Screen.width / 4.07f -48.85f, Screen.height / 2 - 50, 669.9f, 100), "Begin Countdown Suquence",firstStyle)) {
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width / 3.36f - 34.17f, Screen.height / 2 + 50, 520.03f, 100), "Comand Control Guide",firstStyle)) {
			Application.LoadLevel(2);
		}
		if (GUI.Button (new Rect (Screen.width / 3.08f -19.92f, Screen.height / 2 + 150, 446.77f, 100), "Submit Resignation",firstStyle)) {
			Application.Quit();
		}
	}
}
