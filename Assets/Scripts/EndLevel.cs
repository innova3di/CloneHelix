using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace CloneHelix
{
	public class EndLevel : MonoBehaviour 
	{
		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.name == "Player" && GameManager.instance.startGame == true)
			{
				GameManager.instance.nextLevelButton.SetActive(true);
				GameManager.instance.level++;
				GameManager.instance.startGame = false;
				PlayerPrefs.SetInt("LevelAdd", GameManager.instance.level);
			}
		}
	}
}

