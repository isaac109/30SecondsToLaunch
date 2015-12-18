using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	float timer = 0;
	float timeToProblem = 0;
	public problemScreen pS;
	int maxTime = 5;
	int minTime = 3;
	bool gameStart = false;
	// Use this for initialization
	void Start () {
		timeToProblem = Random.Range (minTime, maxTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStart)
		{
			timer += Time.deltaTime;
			if(timer >= timeToProblem)
			{
				timer = 0;
				timeToProblem = Random.Range (0, 5);
				pS.needNewString();
			}
		}
	}
	void OnGUI()
	{
		if (!gameStart) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "START LAUNCH SEQUENCE")) {
				gameStart = true;
				pS.startGame ();
			}
		}
	}
}
