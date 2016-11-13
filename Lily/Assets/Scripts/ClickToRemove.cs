using UnityEngine;
using System.Collections;

public class ClickToRemove : MonoBehaviour
{

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
