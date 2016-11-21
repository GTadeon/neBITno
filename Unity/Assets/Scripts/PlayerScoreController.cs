using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreController : MonoBehaviour {

	public static int score;
	public Text text;
	public Text gameOverTxt;
	public GameObject PickUpParticle;
	public GameObject PlayerDeathParticle;


	public float BatterySpeedIncreaseStep;
	public float BatterySpawnCoolDownTime;

	private ItemSpawnManager itemSpawnManger;

	public AudioSource audioSourcePickUpItem;
	public AudioSource audioSourceLoseScore;
	public AudioSource audioSourceBatteryBoost;
	public AudioSource audioSourceDead;



	void Start()
	{
		itemSpawnManger = GameObject.Find ("GameManager").GetComponent<ItemSpawnManager> ();
		score = 0;
	}

	void OnCollisionEnter(Collision kolizija)
	{	
		if (kolizija.gameObject.tag == "One") 
		{
			audioSourcePickUpItem.Play ();
			score += 1;
			text.text = "B o d o v i : " + score.ToString ();
			ContactPoint contact = kolizija.contacts[0];
			Instantiate (PickUpParticle, contact.point, PickUpParticle.transform.rotation);
		} 
		else if (kolizija.gameObject.tag == "Enemy") 
		{
			audioSourceDead.Play ();
			EndTheGame ();
			ItemMovement.ShouldDestroyAll = true;
			Destroy (kolizija.gameObject);
			Instantiate (PlayerDeathParticle, kolizija.contacts[0].point, PlayerDeathParticle.transform.rotation);
			Destroy (this.gameObject);
		}
		else if (kolizija.gameObject.tag == "Zero")
		{
			audioSourceLoseScore.Play ();
			score = 0;
			text.text = "B o d o v i : " + score.ToString ();

			//ShakeTheScreen ();
		}
		else if (kolizija.gameObject.tag == "Battery")
		{
			audioSourceBatteryBoost.Play ();
			SpeedUpTheGame ();
		}
		else if (kolizija.gameObject.tag == "StartGame")
		{
			audioSourceLoseScore.Play ();
			StartTheGame ();
		}

		Destroy (kolizija.gameObject);
	}

	private IEnumerator BatteryCoolDownCounter()
	{
		ItemSpawnManager.shouldSpawnBattery = false;
		yield return new WaitForSeconds (BatterySpawnCoolDownTime);
		ItemSpawnManager.shouldSpawnBattery = true;
		SlowDownTheGame ();
	}

	private void StartTheGame()
	{
		ItemSpawnManager.shouldSpawnItems = true;
		GameObject[] startGameovi=GameObject.FindGameObjectsWithTag ("StartGame");
		for (int i = 0; i <= startGameovi.Length-1; i++)
		{
			Destroy (startGameovi [i].gameObject );
		}
	}

	private void EndTheGame()
	{
		//gameOverTxt.text="Gotova igra. R za ponovno";
		ItemSpawnManager.shouldSpawnItems = false;
		FloorMovement.speed=-80f;

		itemSpawnManger.StartCoroutine ("SpawnEndGame");
	}


	private void SlowDownTheGame()
	{
		FloorMovement.speed -= BatterySpeedIncreaseStep;
	}

	private void SpeedUpTheGame()
	{
		if ((FloorMovement.speed + BatterySpeedIncreaseStep) < FloorMovement.maxSpeed) 
		{
			StartCoroutine (BatteryCoolDownCounter());
			return;
		}
		else 
		{
			FloorMovement.speed += BatterySpeedIncreaseStep;

		}
	}

}
