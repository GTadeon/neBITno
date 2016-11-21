using UnityEngine;
using System.Collections;

public class ResetFloor : MonoBehaviour {

	public Transform StartingPoint;

	void OnTriggerExit(Collider kolajder)
	{
		if (kolajder.tag=="floor")
		{
			ReturnFloorToStart (kolajder.gameObject);
		}
	}

	private void ReturnFloorToStart(GameObject floorToReturn)
	{
		floorToReturn.transform.position = new Vector3 (floorToReturn.transform.position.x, floorToReturn.transform.position.y, StartingPoint.position.z);
	}
}
