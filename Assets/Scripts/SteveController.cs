using UnityEngine;
using System.Collections;

public class SteveController : MonoBehaviour
{
	public float JumpSpeed = 250;
	public bool OnGround = true;
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (OnGround == true)
			{
				OnGround = false;
				rigidbody.AddForce(0, JumpSpeed, 0);
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			OnGround = true;
		}
	}
}