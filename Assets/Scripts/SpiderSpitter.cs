using UnityEngine;
using System.Collections;

public class SpiderSpitter : MonoBehaviour {

	public Transform Player;
	public Transform SpiderPrefab;
	public float MinSpiderWaitTime = 0.5f;
	public float MaxSpiderWaitTime = 2f;
	private float CurrentSpiderWaitTime = 0f;
	private float WaitTime = 0;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		WaitTime += Time.deltaTime;
		if (WaitTime > CurrentSpiderWaitTime)
		{
			WaitTime = 0;
			CurrentSpiderWaitTime = Random.Range(MinSpiderWaitTime, MaxSpiderWaitTime);
			Transform newTransform = (Transform) Instantiate(SpiderPrefab, this.transform.position, this.transform.rotation);
			SpiderControl newSpider = newTransform.gameObject.GetComponent<SpiderControl>();
			newSpider.Player = Player;
		}
	}
}
