using UnityEngine;
using System.Collections;

public class Hallway : MonoBehaviour 
{
	public GameObject inHall;

	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			inHall = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			inHall = null;
		}
	}
}
