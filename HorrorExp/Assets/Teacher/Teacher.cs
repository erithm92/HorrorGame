using UnityEngine;
using System.Collections;

public class Teacher : MonoBehaviour 
{
	public NavMeshAgent navAgent;
	public GameObject hallway;
	Hallway hallRange;

	public GameObject[] spawnPositions = new GameObject[0];
	public GameObject detention;

	public float reach = 3f;
	public AudioClip grabAudio;

	public GameObject target;

	void Start () 
	{
		navAgent = this.GetComponent<NavMeshAgent> ();

		hallRange = hallway.GetComponentInChildren<Hallway> ();
	}
	
	void Update ()
	{
		// Find the player in the hall
		FindTarget ();

		//find the distance to the player, if close neough, grab them and send them, to detention
		float distance = Vector3.Distance (this.transform.position, target.transform.position);
		if (distance <= reach)
		{
			GrabPlayer();
		}
	}

	void FindTarget()
	{
		if (hallRange.inHall != null)
		{
			target = hallRange.inHall;
			navAgent.destination = target.transform.position;
		}
		else
		{
			navAgent.destination = this.transform.position;
		}
	}

	void GrabPlayer()
	{
		//play sound
		//play grabAudio on players AudioSource

		//send player to detention
		//disable player interaction
		target.transform.position = detention.transform.position;
		target.transform.rotation = detention.transform.rotation;
		//reenable player interaction
	}
	


}
