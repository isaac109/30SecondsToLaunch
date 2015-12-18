using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {

	string title = "Welcome, Commander. The rocket will be preped and ready to fire on your command. Here are the basics you should know to guarentee the safety of the crew and the success of their mission to the station.";
	string screenIntro = "This is your command station. Once the coundown begins, the timer will tick down. After 30 seconds the rocket can take off.";
	string typing = "Error codes and their descriptions will pop up on the screen. To solve an error, you must enter the code into the console.";
	string typing2 = "There is no need to hit enter. Once the typed sequence entered matches the error code, the problem will be resolved.";
	string typing3 = "You have to keep a careful eye on the errors, and solve them quickly. After five errors, the rocket will not launch safely.";
	string goodluck = "Good luck, commander. Their lives are in your hands now.";
	public int section = 1;
	public GUIStyle firstStyle;
	public float y=1;
	public GameObject screen;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(section == 1 || section == 6)
		{
			screen.SetActive(false);
		}
		else
		{
			screen.SetActive(true);
		}
	
	}
	void OnGUI(){
		GUILayout.BeginArea (new Rect (0, 0, 400, 50));
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Exit")) {
			Application.LoadLevel(0);
		}
		if (section > 1) {
			if (GUILayout.Button ("Back")) {
				section --;
			}
		}
		if (section < 6) {
			if (GUILayout.Button ("Next")) {
				section ++;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
		if(section == 1)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height/1.6f),title,firstStyle);
		}
		if(section == 2)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height/1.6f),screenIntro,firstStyle);
		}
		if(section == 3)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height/1.6f),typing,firstStyle);
		}
		if(section == 4)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height/1.6f),typing2,firstStyle);
		}
		if(section == 5)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height/1.6f),typing3,firstStyle);
		}
		if(section == 6)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height/1.6f),goodluck,firstStyle);
		}
	}
}
