using UnityEngine;
using System.Collections;

public class SpiderControl : MonoBehaviour {

	//public Transform Player;
	public float Speed = 10;

	void FixedUpdate ()
	{
		rigidbody.AddForce(Speed * -1, 0, 0);
	}
	void Update ()
	{
		if (this.rigidbody.position.x < -20)
		{
			Destroy(this.gameObject);
		}
	}
}
