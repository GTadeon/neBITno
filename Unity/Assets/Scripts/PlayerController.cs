using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	public float maxX;
	public float minX;

	private Rigidbody m_rigidbody;

	void Start ()
	{

		m_rigidbody = GetComponent<Rigidbody>();
	}


	void Update()
	{
		float movement = Input.GetAxis ("Horizontal");
		m_rigidbody.velocity = new Vector3 (movement*speed, m_rigidbody.velocity.y,0f);

		this.gameObject.transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minX, maxX),transform.position.y,transform.position.z);

	}

}
