using UnityEngine;
using System.Collections;

public class SpiderSpitter : MonoBehaviour {

	public Transform SpiderPrefab;
	public float SpiderWaitTime = 2;
	private float WaitTime = 0;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		WaitTime += Time.deltaTime;
		if (WaitTime > SpiderWaitTime)
		{
			WaitTime = 0;
			Instantiate(SpiderPrefab, this.transform.position, this.transform.rotation);
		}
	}
}
