using UnityEngine;
using System.Collections;

public class endTrigger : MonoBehaviour
{
    public GameObject girls;
    public GameObject scaryFace;
    public float timer = 0;

	// Use this for initialization
	void Start () 
    {
        girls.SetActive(false);
        scaryFace.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            girls.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer = timer + Time.deltaTime;
            if (timer > 5)
            {
                scaryFace.SetActive(true);
            }
            if (timer > 10)
            {
                Application.LoadLevel(0);
            }
        }
    }
}
