using UnityEngine;
using System.Collections;

public class MoverScript : MonoBehaviour {

	public float xmove = 0;
	public float ymove = 0;
	public float speed = 5;
	public Vector3 targetPos;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton (0)) {

			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
			targetPos.z = transform.position.z;
			transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);




		}




	}

