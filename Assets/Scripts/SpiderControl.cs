using UnityEngine;
using System.Collections;

public class SpiderControl : MonoBehaviour {

	public float Speed = 10;

	void FixedUpdate ()
	{
		rigidbody.AddForce(Speed * -1, 0, 0);
	}
}
