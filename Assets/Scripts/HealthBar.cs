using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloneHelix
{
	public class HealthBar : MonoBehaviour {

		Image healthBar;
		float maxHealth =79f;
		public static float health;


		void Start () {

			healthBar = GetComponent<Image> ();
			health = maxHealth;
		}

		void Update () {
			healthBar.fillAmount = health / maxHealth;
			if(GameManager.instance.startGame == false)
            {
				health = maxHealth;
            }
		}
	}
}
