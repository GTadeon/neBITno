using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingText : MonoBehaviour {


	void Start () 
	{
		StartCoroutine(Blink () );
	}

	private IEnumerator Blink()
	{
		for (int i = 1; i <= 34; i++) 
		{
			if (i % 2 == 0) 
			{
				this.gameObject.GetComponent<Text> ().color = Color.black;
				yield return new WaitForSeconds (0.2f);
			}
			else
			{
				this.gameObject.GetComponent<Text> ().color = Color.white;
				yield return new WaitForSeconds (0.2f);
			}
		}
		Destroy (this.gameObject);
		yield return null;
	}

}
