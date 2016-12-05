using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float TimeRemaining = 60;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimeRemaining -= Time.deltaTime;
	}

    void OnGUI()
    {
        if(TimeRemaining > 0)
        {
            GUI.Label(new Rect(700, 100, 200, 100), "Time Remaining : " + (int)TimeRemaining);
        }
        else
        {
            GUI.Label(new Rect(100, 100, 100, 100), "Time's up");
        }
    }
}
