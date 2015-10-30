using UnityEngine;
using System.Collections;

public class giggleTrigger : MonoBehaviour
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("hi");
            GetComponent<AudioSource>().Play();
        }
    }
}
