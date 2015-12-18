using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {
	public double time = 30;
	public bool start = false;
	bool lost = false;
	bool won = false;
	public float x;
	public float y;
	public GUIStyle mystyle;
	public GUIStyle mystyle2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!mystyle.stretchWidth) {
			mystyle.stretchWidth = true;
		}
		if (mystyle.stretchHeight) {
			mystyle.stretchHeight = false;
		}
		if(start)
			time -= Time.deltaTime;
		if(time <= 0)
		{
			wonGame();
		}
	}

	void OnGUI()
	{
		if (start) {
			if (time >= 10) {
				GUI.Box (new Rect (Screen.width/3.37f - 53.38f, Screen.height/1.5f, 75, 50), time.ToString ().Substring (0, 2),mystyle); 
			} else {
				GUI.Box (new Rect (Screen.width/3.37f - 53.38f, Screen.height/1.5f, 100, 50), time.ToString ().Substring (0, 1),mystyle); 

			}
		}
		if(won)
		{
			GUI.Box (new Rect (Screen.width / 2 - 150, Screen.height / 2, 300, 40), "Houstan, the launch was a success. See you up there.", mystyle2);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50 , 250, 100), "START NEW LAUNCH SEQUENCE"))
            {
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 140, 250, 100), "SUBMIT RESIGNATION "))
            {
               Application.Quit();
            }
		}
		if(lost)
		{
			GUI.Box (new Rect (Screen.width / 2.41f - 23.34f, Screen.height / 2 , 250, 40), "Houstan! What's happening?! Please, HEL...", mystyle2);
            if (GUI.Button(new Rect(Screen.width / 2 - 450, Screen.height / 2 - 50, 250, 100), "START NEW LAUNCH SEQUENCE"))
            {
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 200, Screen.height / 2 - 50, 250, 100), "SUBMIT RESIGNATION"))
            {
                Application.Quit();
            }
		}
	}

	public void startGame()
	{
		start = true;
	}
	public void lostGame()
	{
		start = false;
		lost = true;
	}
	public void wonGame()
	{
		start = false;
		won = true;
	}
}
