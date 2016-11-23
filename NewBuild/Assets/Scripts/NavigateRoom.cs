using UnityEngine;
using System.Collections;

public class NavigateRoom : MonoBehaviour {

    public GameObject CurrentRoom;
    public GameObject NextRoom;

	void OnMouseUpAsButton()
    {
        NextRoom.SetActive(true);
        CurrentRoom.SetActive(false);
    }
}
