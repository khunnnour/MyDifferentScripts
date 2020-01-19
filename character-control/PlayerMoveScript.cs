using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
	public float speed = 10.0f;
	public float jump = 10.0f;
	
	private Rigidbody rb;
	private float xMove;
	private float yMove;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		GetInput();
		Move();
	}

	void GetInput()
	{
		xMove = Input.GetAxis("Horizontal");
		yMove = Input.GetAxis("Vertical");

		if (Input.GetKeyDown(KeyCode.Space))
			Jump();
	}

	void Move()
	{
		float fall = rb.velocity.y;
		Vector3 dir = transform.forward * yMove + transform.right * xMove;

		dir.Normalize();
		dir *= speed;
		dir.y = fall;

		rb.velocity = dir;

		rb.angularVelocity = Vector3.zero;
	}

	void Jump()
	{
		rb.AddForce(transform.up * jump);
	}
}