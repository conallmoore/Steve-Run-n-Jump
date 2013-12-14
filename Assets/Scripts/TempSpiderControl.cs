using UnityEngine;
using System.Collections;

public class TempSpiderControl : MonoBehaviour {

	public float Speed = 10;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rigidbody.position.x < -20)
		{
			Destroy (this.gameObject);
		}
	}

	void FixedUpdate()
	{
		rigidbody.AddForce(Speed * -1, 0, 0);
	}
}
