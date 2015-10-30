using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hallway : MonoBehaviour 
{
	public GameObject inHall;
	public bool teacherActive = false;

	public GameObject teacher;
	Teacher teacherScript;
	public List<GameObject> teacherSpawnLocations = new List<GameObject>();

	void Start () 
	{
		if (teacher != null)
			teacherScript = teacher.GetComponent<Teacher> ();
	}
	

	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.transform.parent.name == "Player")
		{
			inHall = other.gameObject;

			if(!teacherActive)
			{
				GameObject spawnLocation;
				int randomMax = teacherSpawnLocations.Count;

				//check distance to spawn, if too close, roll again
				bool spawnOK = false;
				while (spawnOK == false)
				{
					spawnLocation = teacherSpawnLocations[Random.Range(0, randomMax)];

					//check distance of player to spawn location
					float distance = Vector3.Distance(spawnLocation.transform.position, other.gameObject.transform.position);

					//if outside the range, spawnOK = true
					if( distance > 25f)
					{
						spawnOK = true;

						teacher.SetActive(true);
						teacher.transform.position = spawnLocation.transform.position;
					}
				}
			}

		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.transform.parent.name == "Player")
		{
			inHall = null;
		}
	}
}
