using UnityEngine;
using System.Collections;

public class ItemSpawnManager : MonoBehaviour {

	public GameObject StartGameTxtObject;
	public GameObject EndGameTxtObject;
	public GameObject[] spawnItems;
	public float minX;
	public float maxX;

	public float posZ;
	public Transform player;

	public float minSpawnWaitTime;
	public float maxSpawnWaitTime;
	public static bool shouldSpawnBattery;
	public static bool canSpawnZero; //u bilo kojem trenutku, samo 1 nula moze biti na sceni. Spawna se 1 u 10 sec samo!
	public static bool canSpawnEnemy; // enemy spawnam jednom u 5 sec!

	public static bool shouldSpawnItems;
	private bool hasSpawnedOne;

	private float ItemYSpawnPos;

	void Start()
	{
		ItemYSpawnPos = player.transform.position.y;
		shouldSpawnItems = false;
		shouldSpawnBattery = true;
		canSpawnZero = true;
		canSpawnEnemy = true;
		hasSpawnedOne = false;
		StartCoroutine (SpawnStartGame());
	}
		

	private IEnumerator SpawnStartGame()
	{
		yield return new WaitForSeconds (maxSpawnWaitTime);
		if (shouldSpawnItems==false) 
		{
			Vector3 startPos = new Vector3(Random.Range (minX, maxX), ItemYSpawnPos, posZ);
			Instantiate (StartGameTxtObject, startPos,StartGameTxtObject.transform.rotation);
			StartCoroutine (SpawnStartGame());
		} 
		else 
		{
			StartCoroutine (SpawnItems());
		}
		yield return null;
	}

	public IEnumerator SpawnEndGame()
	{
		yield return new WaitForSeconds (maxSpawnWaitTime);
		if (shouldSpawnItems==false) 
		{
			Vector3 startPos = new Vector3(Random.Range (minX, maxX), ItemYSpawnPos, posZ);
			Instantiate (EndGameTxtObject, startPos,EndGameTxtObject.transform.rotation);
			StartCoroutine (SpawnEndGame());
		} 
		/*
		else 
		{
			StartCoroutine (SpawnItems());
		}
		*/
		yield return null;
	}

	private IEnumerator SpawnItems()
	{
		if (ItemMovement.ShouldDestroyAll == true)
			yield break;
		yield return new WaitForSeconds (Random.Range(minSpawnWaitTime, maxSpawnWaitTime));
		try
		{
			GameObject item = spawnItems[Random.Range (0,spawnItems.Length)];
			if (item.tag=="Battery" && shouldSpawnBattery==false && shouldSpawnItems==true)
				StartCoroutine(SpawnItems());
			else if (item.tag=="Zero")
			{
				if (canSpawnZero==true)
				{
					StartCoroutine ( ZeroSpawnCounter() );
					Vector3 itemPos = new Vector3(Random.Range (minX, maxX), ItemYSpawnPos, posZ);
					Instantiate (item,itemPos,item.transform.rotation);
				}
				else if (shouldSpawnItems==true)
					StartCoroutine(SpawnItems());
			}
			else if (item.tag=="Enemy")
			{
				if (canSpawnEnemy==true)
				{
					StartCoroutine ( EnemySpawnCounter() );
					Vector3 itemPos = new Vector3(Random.Range (minX, maxX), ItemYSpawnPos, posZ);
					Instantiate (item,itemPos,item.transform.rotation);
				}
				else if (shouldSpawnItems==true)
					StartCoroutine(SpawnItems());
			}
			else 
			{
				Vector3 itemPos = new Vector3(Random.Range (minX, maxX), ItemYSpawnPos, posZ);
				Instantiate (item,itemPos,item.transform.rotation);
			}
		} 
		catch {Debug.Log ("unisten je taj item");}
		if (shouldSpawnItems == true) 
		{
			StartCoroutine (SpawnItems());
		}
		yield return null;
	}

	void Update()
	{
		if (shouldSpawnItems == true && hasSpawnedOne==false) 
		{
			InvokeRepeating ("SpawnOne",1f, 1f);
			hasSpawnedOne = true;

		}

	}

	private void SpawnOne()
	{
		if (shouldSpawnItems == true) 
		{
			Vector3 itemPos = new Vector3(Random.Range (minX, maxX), ItemYSpawnPos, posZ);
			Instantiate(spawnItems[1].gameObject, itemPos, spawnItems[1].transform.rotation);
		}
	}

	private IEnumerator ZeroSpawnCounter()
	{
		canSpawnZero = false;
		yield return new WaitForSeconds (10f);
		canSpawnZero = true;
		yield return null;
	}

	private IEnumerator EnemySpawnCounter()
	{
		canSpawnEnemy = false;
		yield return new WaitForSeconds (5f);
		canSpawnEnemy = true;
		yield return null;
	}
}
