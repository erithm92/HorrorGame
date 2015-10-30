using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour 
{
	public enum ObjectType {pickUp, key, door, battery}

	public ObjectType thisType;
	bool held = false;
	bool open = false;
	GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("PlayerBody");
	}
	public void PerformFunction()
	{
		if (thisType == ObjectType.pickUp) 
			PickUp ();

		if (thisType == ObjectType.key)
			Key ();

		if (thisType == ObjectType.door) 
			Door ();

		if (thisType == ObjectType.battery)
			Battery ();

	}
	void PickUp()
	{
		if (!held) 
		{
			gameObject.transform.parent = player.transform;
			transform.position = player.transform.position + player.transform.forward;
			held = true;
		}
		if (held)
		{
			gameObject.transform.parent = null;
		}
	}
	void Key()
	{

	}
	void Door()
	{
		if (!open) 
		{
			transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.x,
			                                                    transform.rotation.y + 90,
			                                                    transform.rotation.z));
			open = true;
		}
		if (open)
		{
			transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.x,
			                                                    transform.rotation.y - 90,
			                                                    transform.rotation.z));
			open = false;
		}
	}
	void Battery()
	{
		
	}
}
