using UnityEngine;
using System.Collections;

public class ConveyorBelt : MonoBehaviour {

    public float conveyorSpeed = -.1f;
    public float maxSpeed = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionStay(Collision other)
    {
        if (other.rigidbody.velocity.magnitude < maxSpeed)
        {
            other.rigidbody.AddForce(0f, 0, conveyorSpeed, ForceMode.Impulse);
        }
    }
}
