using UnityEngine;
using System.Collections;

public class SpeedParticles : MonoBehaviour {

	private float speed;
	
	private ParticleEmitter particleEmitter;

	void Start () 
	{
		particleEmitter = GetComponent<ParticleEmitter> ();
	}
	

	void Update () 
	{

		particleEmitter.emit = true;
		Vector3 aux = particleEmitter.localVelocity;
		aux.z = - (5f *50)/20;
		particleEmitter.localVelocity = aux;

	}
}
