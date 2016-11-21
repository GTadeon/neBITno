using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIfunctions : MonoBehaviour {


	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			RestartGame ();
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (0);
	}
}
