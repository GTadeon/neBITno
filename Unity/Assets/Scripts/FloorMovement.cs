using UnityEngine;
using System.Collections;

public class FloorMovement : MonoBehaviour {

	public static float speed;
	public static float maxSpeed;
	private Rigidbody m_rigidbody;

	void Awake ()
	{
		speed = -80f;
		maxSpeed = -160f;
	}

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}


	void Update()
	{
		m_rigidbody.velocity = new Vector3 (m_rigidbody.velocity.x, m_rigidbody.velocity.y, speed );

	}

}
