using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour
{

    public SpriteRenderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        rend.material.color = Color.blue;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
	/*
	void OnMouseDown()
	{
		Destroy (gameObject);
	}
	*/
   
}