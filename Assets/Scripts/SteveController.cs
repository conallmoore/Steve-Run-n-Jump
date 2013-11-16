using UnityEngine;
using System.Collections;

public class SteveController : MonoBehaviour {

	public float JumpSpeed = 350;
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(0, JumpSpeed, 0);
		}
	}
}
