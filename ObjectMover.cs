using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{

		float dy = Input.GetAxis("Vertical") * 0.1f;
		float dx = Input.GetAxis("Horizontal") * 0.1f;

		if (Input.GetKey("up"))
		{
			transform.Translate(0, dy, 0);
		}

		if (Input.GetKey("down"))
		{
			transform.Translate(0, dy, 0);
		}

		if (Input.GetKey("left"))
		{
			transform.Translate(dx, 0, 0);
		}

		if (Input.GetKey("right"))
		{
			transform.Translate(dx, 0, 0);
		}
		if (Input.GetKey(KeyCode.U))
		{
			transform.Rotate(1f, 0, 0);
		}
		if (Input.GetKey(KeyCode.I))
		{
			transform.Rotate(-1f, 0, 0);
		}
		if (Input.GetKey(KeyCode.J))
		{
			transform.Rotate(0, 1f, 0);
		}
		if (Input.GetKey(KeyCode.K))
		{
			transform.Rotate(0, -1f, 0);
		}
		if (Input.GetKey(KeyCode.N))
		{
			transform.Rotate(0, 0, 1f);
		}
		if (Input.GetKey(KeyCode.M))
		{
			transform.Rotate(0, 0, -1f);
		}
	}
}
