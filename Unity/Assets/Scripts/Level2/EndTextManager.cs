using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndTextManager : MonoBehaviour {

	public Text finalTxt;
	public float pauseBetweenWords;
	private string [] Words = {"Bravo. ", "Uspjesno ste potrgali igru. ","Mislim, fakat bravo."};

	void Start()
	{
		StartCoroutine (Type());
	}

	private IEnumerator Type()
	{
		yield return new WaitForSeconds (1.5f);
		for (int i = 0; i <= Words.Length-1; i++) 
		{
			finalTxt.text += Words [i];
			yield return new WaitForSeconds (pauseBetweenWords);
		}
		StartCoroutine (Indicate());
		yield return null;

	}
		
	
	private IEnumerator Indicate()
	{
		for (int i = 0; i < 3; i++)
		{
			finalTxt.text += ".";
			yield return new WaitForSeconds (0.15f);
		}
		finalTxt.text = Words [0] + Words [1] + Words [2];
		StartCoroutine (Indicate());
	}

}
