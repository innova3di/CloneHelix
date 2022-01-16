using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloneHelix
{
	public class Player : MonoBehaviour {
	
		public Button RestartButton;
		public Button Quit;
		public Text textscore;
		public Text bestScoreText;
		public Vector3 currentPositon;
		public int score;
		private int bestScore;
		//public AudioSource ;
		public AudioClip jumpSound;
		public AudioClip destSound;

		private Rigidbody rb;
		void Start ()
		{
			rb = GetComponent<Rigidbody>();
			currentPositon = transform.position;
			score = 0;
		}

        private void Update()
        {
			ScoreManager();
			if (GameManager.instance.startGame == true)
            {
				rb.isKinematic = false;
            }
            else
            {
				rb.isKinematic = true;
			}
        }

		public void ScoreManager()
        {
			textscore.text = score.ToString();
			bestScore = PlayerPrefs.GetInt("Best", score);
			bestScoreText.text = bestScore.ToString();
		}

        // ball when Toche redBar
        void OnTriggerEnter(Collider other) 
		{
            if (other.gameObject.CompareTag("Enemy"))
            {
                RestartButton.gameObject.SetActive(true);
                Quit.gameObject.SetActive(true);
                GameManager.instance.startGame = false;
            }
		}

		void OnTriggerExit(Collider other) 
		{
			if(other.gameObject.name == "Circle")
			{
				HealthBar.health -= 1f;
				AudioSource audio = GetComponent<AudioSource>();
				if (GameManager.instance.soundOn == true) audio.PlayOneShot (destSound);
				if (RestartButton.gameObject.activeInHierarchy == false)
				{
					score++;
				}
				if (score > bestScore) PlayerPrefs.SetInt("Best", score);
				textscore.text = "" + score.ToString();
                other.gameObject.SetActive(false);
			}

			//if (other.gameObject.CompareTag("ScoreBar"))
			//{
			//	if (RestartButton.gameObject.activeInHierarchy == false)
			//	{
			//		score++;
			//	}
			//	if (score > bestScore) PlayerPrefs.SetInt("Best", score);
			//	textscore.text = "" + score.ToString();
			//	other.gameObject.SetActive(false);
			//}

		}

		void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.name=="Bar")
			{
				AudioSource audio = GetComponent<AudioSource> ();
				if(GameManager.instance.soundOn == true) audio.PlayOneShot (jumpSound);
			}
		}
	}

}