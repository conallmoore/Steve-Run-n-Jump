using UnityEngine;
using System.Collections;

public class SteveController : MonoBehaviour
{
	public float JumpSpeed = 250;
	public bool OnGround = true;
	public GUIText LivesText;
	int Lives = 3;

	void Start()
	{
		//Setting the lives text
		LivesText.text = "Lives: " + Lives;
	}

	void Update ()
	{
		//Jumping code
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (OnGround == true)
			{
				OnGround = false;
				rigidbody.AddForce(0, JumpSpeed, 0);
				animation.Play("Jump");
			}
		}
		//Kill code
		if (Lives < 0)
		{
			LivesText.text = "Dead";
			Destroy(this.gameObject);
		}
	}


	//Checking for collision
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			OnGround = true;
			animation.Play("Run");
		}
		if (collision.gameObject.tag == "Enemy")
		{
			Lives -= 1;
			LivesText.text = "Lives: " + Lives;
		}
	}
}