using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloneHelix
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager soundInstance;
        private AudioSource ostGame;
        [System.Obsolete]
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (soundInstance == null)
            {
                soundInstance = this;
            }
            else
            {
                DestroyObject(this.gameObject);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            ostGame = GetComponent<AudioSource>(); 
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.toggleSound.isOn == true)
            {
               ostGame.enabled = true;
               GameManager.instance.soundOn = true;
            }
            else
            {
                ostGame.enabled = false;
                GameManager.instance.soundOn = false;
            }
        }
    }
}
