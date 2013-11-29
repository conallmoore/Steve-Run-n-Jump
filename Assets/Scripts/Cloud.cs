using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	public float Speed = 1f;
	public CloudGenerator Generator {get;set;}

	// Use this for initialization
	void Start () {
		//this.generator = ((ICloudGenerator) this.transform.parent);
		this.Speed = Random.Range(Speed * .75f, Speed * 1.5f);
		this.transform.Translate(0, Random.Range (-5,5),0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = this.transform.position;
		newPosition.x -= Speed * Time.deltaTime;
		if (newPosition.x < Generator.MinX) {
			//newPosition.x += MaxX * 2;
			Generator.AddCloud (this.transform.position.z);
			Destroy(this.gameObject);
		} else {
			this.transform.position = newPosition;
		}
	}
}
