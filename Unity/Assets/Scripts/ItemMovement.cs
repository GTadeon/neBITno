using UnityEngine;
using System.Collections;

public class ItemMovement : MonoBehaviour {

	private float speed;
	private Rigidbody m_rigidbody;
	public static float DestroyAfterZ;

	public static bool ShouldDestroyAll; //ne primjenuje se na game over i start game objekte!


	void Start ()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		DestroyAfterZ = -3f;
		ShouldDestroyAll = false;
	}

	void Update()
	{
		if (ShouldDestroyAll == true && this.gameObject.tag != "GameOver" && this.gameObject.tag != "StartGame") 
		{
			Destroy (this.gameObject);
		}

		if (this.gameObject.transform.position.z < DestroyAfterZ)
			Destroy (this.gameObject);
		speed = FloorMovement.speed / 4;
		if (this.gameObject.tag == "One")
			this.speed = -70f;
		m_rigidbody.velocity = new Vector3 (m_rigidbody.velocity.x, m_rigidbody.velocity.y, speed );



	}
}
