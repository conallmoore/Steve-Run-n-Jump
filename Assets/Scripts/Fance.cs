using UnityEngine;
using System.Collections;

public class Fance : MonoBehaviour {

	public int PanelCount = 2;
	public Transform FencePanelPrefab;
	public Transform FencePostPrefab;
	private float PanelWidth = -1.2f;
	private float PostOffsetX = .7f;
	private float PostOffsetY = -.2f;

	// Use this for initialization
	void Start () {
		Vector3 pos;
		for (int i = 1 ; i < PanelCount ; i++) {
			pos = new Vector3(transform.position.x + (i * PanelWidth), transform.position.y, transform.position.z);
			Instantiate(FencePanelPrefab, pos, this.transform.rotation);
		}
		pos = new Vector3(transform.position.x + (PanelCount * PanelWidth) + PostOffsetX, transform.position.y + PostOffsetY, transform.position.z);
		Instantiate(FencePostPrefab, pos, this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
