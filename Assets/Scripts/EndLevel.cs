using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EndLevel : MonoBehaviour {
	
	public Button nextLevel;
	public string levelName;


	void OnTriggerEnter(Collider other)
		{
		
		    if(other.gameObject.name == "Player")
		{
			nextLevel.gameObject.SetActive (true);


			//SceneManager.LoadScene (levelName);
		}
	}
}

