using UnityEngine;
using System.Collections;

public class girlsTrigger : MonoBehaviour 
{
    public GameObject girl1;
    public GameObject girl2;
    public GameObject light;

    public float timer = 0.0f;
	// Use this for initialization
	void Start ()
    {
        girl1.SetActive(true);
        girl2.SetActive(false);
        light.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            girl1.SetActive(false);
            girl2.SetActive(true);
        
        }
    }

    void OnTriggerStay(Collider other)
    {
        lightning();
    }

    public void lightning()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0 && timer <= 0.2)
        {
            light.SetActive(true);
        }
        if (timer >= 0.2 && timer <= 0.4)
        {
            light.SetActive(false);
        }
        if (timer >= 0.4 && timer <= 0.6)
        {
            light.SetActive(true);
        }
        if (timer >= 0.6 && timer <= 0.8)
        {
            light.SetActive(false);
        }
        if (timer >= 0.8 && timer <= 1.0)
        {
            light.SetActive(true);
        }
        if (timer >= 1.0 && timer <= 1.2)
        {
            light.SetActive(false);
        }
        if (timer >= 1.2 && timer <= 1.4)
        {
            light.SetActive(false);
        }
    }
}
