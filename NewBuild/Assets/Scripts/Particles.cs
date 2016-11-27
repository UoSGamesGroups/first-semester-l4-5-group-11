using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {

    void Start()
    {
        // You can use particleSystem instead of
        // gameObject.particleSystem.
        GetComponent<ParticleSystem>().emissionRate = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<ParticleSystem>().Emit(10);
        }
    }
}