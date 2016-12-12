using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public int fontSize;

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
 {
            if (Time.time >= 30) // If more than 20 seconds has elapsed  
                GUI.Label(new Rect(10, 10, 100, 100), "Time is running out!");
        }
        if (TimeRemaining > 0)
        {
            GUI.Label(new Rect(700, 100, 200, 100), "Time Remaining : " + (int)TimeRemaining);
        }
        else
        {
            GUI.Label(new Rect(700, 100, 200, 100), "Time's up");
        }
    }
}
