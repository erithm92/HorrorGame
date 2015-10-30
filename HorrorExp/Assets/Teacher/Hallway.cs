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
		if(other.gameObject.name == "Player")
		{
			inHall = other.gameObject;
			if(!teacherActive)
			{
				GameObject spawnLocation;
				int randomMax = teacherSpawnLocations.Count;

				spawnLocation = teacherSpawnLocations[Random.Range(0, randomMax)];

				teacher.SetActive(true);
				teacher.transform.position = spawnLocation.transform.position;
			}
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
