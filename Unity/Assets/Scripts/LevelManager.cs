using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public int MaxNumberOfObjects;
	private int currentNumberOfObjectesInScene;

	void Start()
	{
		currentNumberOfObjectesInScene = 0;
	}

	void Update ()
	{
		int numbOfZero = GameObject.FindGameObjectsWithTag ("Zero").Length;
		int numbOfOne = GameObject.FindGameObjectsWithTag ("One").Length;
		int numbOfEnemies = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		int numbOfBatteries = GameObject.FindGameObjectsWithTag ("Battery").Length;

		currentNumberOfObjectesInScene = numbOfZero + numbOfOne + numbOfEnemies + numbOfBatteries;

		if (currentNumberOfObjectesInScene >= MaxNumberOfObjects)
			SceneManager.LoadScene (1);
		
	}
}
