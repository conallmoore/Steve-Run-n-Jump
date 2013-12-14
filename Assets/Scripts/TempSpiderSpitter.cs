using UnityEngine;
using System.Collections;

public class TempSpiderSpitter : MonoBehaviour
{
	public Transform SpiderPrefab;
	public float SpiderWaitTime = 1.5f;
	private float WaitTime = 0f;

	void Start ()
	{
		
	}

	void Update ()
	{
		WaitTime += Time.deltaTime;
		if (WaitTime > SpiderWaitTime) {
			WaitTime = 0f;
			GenerateSpider();
		}
	}

	void GenerateSpider()
	{
		Instantiate (SpiderPrefab, this.transform.position, this.transform.rotation);
	}
}