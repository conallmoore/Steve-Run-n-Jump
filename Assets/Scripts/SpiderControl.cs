using UnityEngine;
using System.Collections;

public class SpiderControl : MonoBehaviour {

	public Transform Player;
	private float initialPlayerDistance;
	public float Speed = 10;

	void FixedUpdate ()
	{
		rigidbody.AddForce(Speed * -1, 0, 0);
	}
	
	void Start ()
	{
		initialPlayerDistance = Vector3.Distance(this.transform.position, Player.transform.position);
	}

	void Update ()
	{
		if (Player != null) {
			if (Vector3.Distance(this.transform.position, Player.transform.position) > initialPlayerDistance * 2)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
