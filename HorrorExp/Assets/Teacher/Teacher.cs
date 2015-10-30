using UnityEngine;
using System.Collections;

public class Teacher : MonoBehaviour 
{
	public NavMeshAgent navAgent;
	public GameObject hallway;
	Hallway hallRange;
	
	public GameObject detention;

	public float reach = 3f;
	public AudioClip grabAudio;

	public GameObject target;

	void Start () 
	{
		navAgent = gameObject.GetComponent<NavMeshAgent> ();

		hallRange = hallway.GetComponent<Hallway> ();
	}
	
	void Update ()
	{
		// Find the player in the hall
		FindTarget ();

		//find the distance to the player, if close neough, grab them and send them, to detention
		float distance = 0f;
		if(target != null)
		{
			distance = Vector3.Distance (gameObject.transform.position, target.transform.position);

			if (distance <= reach)
			{
				GrabPlayer();
			}
		}
	}

	void FindTarget()
	{
		if (hallRange.inHall != null)
		{
			if(target == null)
				hallRange.teacherActive = true;

			target = hallRange.inHall;
			navAgent.destination = target.transform.position;
		}
		else
		{
			target = null;
			navAgent.destination = gameObject.transform.position;
			//fade away
			hallRange.teacherActive = false;
			gameObject.SetActive(false);
		}
	}

	void GrabPlayer()
	{
		//play sound
		//play grabAudio on players AudioSource

		//send player to detention
		target.GetComponent<PlayerScript> ().playerDisabled = true;

		//fade out to black

		//move player to detention
		target.transform.position = detention.transform.position;
		target.transform.rotation = detention.transform.rotation;

		//fade in to black

		//reenable player interaction
		target.GetComponent<PlayerScript> ().playerDisabled = false;

		target = null;
		hallRange.inHall = null;
	}
	


}
