using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEvent : MonoBehaviour {

	public byte id;
	public string EventName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateData()
	{
		EventName = ((EventID)id).ToString();
	}
}
