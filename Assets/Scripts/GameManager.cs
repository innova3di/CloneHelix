using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CloneHelix
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public bool soundOn;
        public bool startGame;
        public Player playerScript;
        public GameObject playerGameObject;
        public Toggle toggleSound;
        public AudioSource ostGame;
        public GameObject startPanel;
        public GameObject nextLevelButton;
        public Text levelText;
        public int level;
        public bool changeLevel;
        

        private GameObject[] textEN;
        private GameObject[] textRU;
        private GameObject circles;
        private Transform[] circleChild;
        private GameObject[] cloneObject;
        public void Awake()
        {
            //PlayerPrefs.DeleteAll();
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        private void Start()
        {
            playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerScript = playerGameObject.GetComponent<Player>();
            startPanel = GameObject.FindGameObjectWithTag("StartPanel");
            textEN = GameObject.FindGameObjectsWithTag("TextEn");
            textRU = GameObject.FindGameObjectsWithTag("TextRu");
            circles = GameObject.FindGameObjectWithTag("AxeCircle");
            ostGame = GetComponent<AudioSource>();
            circleChild = circles.GetComponentsInChildren<Transform>();
        }

        private void Update()
        {
            cloneObject = GameObject.FindGameObjectsWithTag("Circle");
            LevelManager();

            if (startGame == false)
            {
                UpdateRandomCircle();
            }
            if(changeLevel == true)
            {
                circleChild = circles.GetComponentsInChildren<Transform>();
            }
          
        }

        public void UpdateRandomCircle()
        {
            foreach (Transform child in circleChild)
            {
                if(child != null)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }

        public void LevelManager()
        {
            level = PlayerPrefs.GetInt("LevelAdd", level);
            levelText.text = level.ToString();
        }


        public void StartGame()
        {
            startGame = true;
            startPanel.SetActive(false);
        }

        public void ToggleSound()
        {
            if (toggleSound.isOn == true)
            {
                ostGame.enabled = true;
                soundOn = true;
            }
            else
            {
                ostGame.enabled = false;
                soundOn = false;
            }
        }

        public void ChangeLanguage()
        {
            foreach(GameObject child in textEN)
            {
                Text textEnChild = child.GetComponent<Text>();
                if (textEnChild.enabled == false)
                {
                    textEnChild.enabled = true;
                }
                else
                {
                    textEnChild.enabled = false;
                }
            }

            foreach(GameObject child in textRU)
            {
                Text textRuChild = child.GetComponent<Text>();
                if (textRuChild.enabled == false)
                {
                    textRuChild.enabled = true;
                }
                else
                {
                    textRuChild.enabled = false;
                }
            }
        }

        public void RestartGame()
        {
            playerScript.gameObject.transform.position = playerScript.currentPositon;
            playerScript.RestartButton.gameObject.SetActive(false);
            startGame = false;
            startPanel.SetActive(true);
            playerScript.score = 0;
        }

        public void ChangeLevel()
        {
            playerScript.gameObject.transform.position = playerScript.currentPositon;
            nextLevelButton.SetActive(false);
            startGame = false;
            startPanel.SetActive(true);
            changeLevel = true;
            foreach (GameObject clone in cloneObject)
            {
                Destroy(clone);
            }
      
            Invoke("ChangeNextLevel", 0.3f);
        }

        public bool ChangeNextLevel()
        {
            return changeLevel = false;
        }
    }

}
