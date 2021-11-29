using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public Button RestartButton;
	public Button Quit;
	public Text textscore;
	public Text bestScore;
	private int score;
	//public AudioSource ;
	public AudioClip jumpSound;
	public AudioClip destSound;


	void Start (){

		Time.timeScale = 1.5f;
		score = 0;
		bestScore.text = "Best: " + PlayerPrefs.GetFloat ("Best");

	}
	
	// ball when Toche redBar
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.name == "Enmy")
		{
			RestartButton.gameObject.SetActive (true);
			Quit.gameObject.SetActive (true);
			Time.timeScale = 0f;

		}

		if(other.gameObject.name == "ScoreBar") 
		{
			score = score + 1;
			if(PlayerPrefs.GetFloat ("Best") < score)
			   PlayerPrefs.SetFloat ("Best", score);
			
			textscore.text = "" + score.ToString();
			other.gameObject.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.name == "Circle")
		{
			HealthBar.health -= 1f;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.PlayOneShot (destSound);
			other.gameObject.SetActive (false);

		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name=="Bar")
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.PlayOneShot (jumpSound);
		}
	}
}