using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	Rigidbody rb;
	public float moveSpeed = 5;
	public GameObject cam;
	public GameObject flashLight;
	Light light;
	bool on = false;

	public float battLife = 100.0f;

	float intensity;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		light = flashLight.GetComponent<Light> ();
		intensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (light.enabled) 
		{
			battLife -= Time.deltaTime * 2f;
		}

		if (battLife <= 10) 
		{
			StartCoroutine ("Flicker");
		}
		if (battLife <= 0) 
		{
			on = false;
		}
		if(battLife<30)
		battLife += Time.deltaTime;

		transform.rotation = Quaternion.Euler(new Vector3(0,cam.transform.rotation.eulerAngles.y,0));
		Vector3 move = Vector3.zero;
		if (Input.GetKey (KeyCode.W))
		{
			move += transform.forward;
		}
		if (Input.GetKey (KeyCode.A))
		{
			move -= transform.right;
		}
		if (Input.GetKey (KeyCode.S))
		{
			move -= transform.forward;
		}
		if (Input.GetKey (KeyCode.D))
		{
			move += transform.right;
		}
		if (move != Vector3.zero)
			rb.transform.position += move *moveSpeed * Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			on = !on;
		}
		if (on) 
		{
			light.enabled = true;
		}
		else
			light.enabled = false;
	}
	IEnumerator Flicker()
	{
		while (light.intensity > 0) 
		{
			light.intensity --;
		}

		yield return new WaitForSeconds (Random.Range (0.2f, 0.8f));

		while (light.intensity < intensity)
		{
			light.intensity ++;
		}

	}
}
