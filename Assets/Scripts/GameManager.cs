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
        public GameObject textEn;
        public GameObject textRu;

        private GameObject circles;
        private Transform[] circleChild;
        private GameObject[] cloneObject;
        private NewBehaviourScript mainCam;
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
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NewBehaviourScript>();
            playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerScript = playerGameObject.GetComponent<Player>();
            startPanel = GameObject.FindGameObjectWithTag("StartPanel");
            circles = GameObject.FindGameObjectWithTag("AxeCircle");
            ostGame = GetComponent<AudioSource>();
            circleChild = circles.GetComponentsInChildren<Transform>();
        }

        private void Update()
        {
            Debug.Log("Level:" + level);
            LevelManager();
            cloneObject = GameObject.FindGameObjectsWithTag("Circle");
            if (startGame == false)
            {
                UpdateRandomCircle();
            }

            if(changeLevel == true)
            {
                circleChild = circles.GetComponentsInChildren<Transform>();
            }

            if(nextLevelButton.activeInHierarchy == true)
            {
                foreach (GameObject clone in cloneObject)
                {
                    Destroy(clone);
                }
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
            if(textEn.activeInHierarchy == false)
            {
                textEn.SetActive(true);
            }
            else
            {
                textEn.SetActive(false);
            }

            if(textRu.activeInHierarchy == false)
            {
                textRu.SetActive(true);
            }
            else
            {
                textRu.SetActive(false);
            }
        }

        public void RestartGame()
        {
            playerScript.gameObject.transform.position = playerScript.currentPositon;
            playerScript.gameOverPanel.SetActive(false);
            startGame = false;
            startPanel.SetActive(true);
            playerScript.score = 0;
        }

        public void RetryGame()
        {
            playerScript.gameObject.transform.position = playerScript.currentPositon;
            playerScript.gameOverPanel.SetActive(false);
            mainCam.SetTransformPosition();
            startGame = true;
            playerScript.score = 0;
        }

        public void ChangeLevel()
        {
            playerScript.gameObject.transform.position = playerScript.currentPositon;
            nextLevelButton.SetActive(false);
            mainCam.SetTransformPosition();
            startGame = true;
            changeLevel = true;
            Invoke("ChangeNextLevel", 0.3f);
        }

        public void MainMenu()
        {
            playerScript.gameObject.transform.position = playerScript.currentPositon;
            nextLevelButton.SetActive(false);
            startGame = false;
            startPanel.SetActive(true);
            changeLevel = true; 
            Invoke("ChangeNextLevel", 0.3f);
        }

        public void QuitGame()
        {
            Application.Quit(0);
        }

        public bool ChangeNextLevel()
        {
            return changeLevel = false;
        }
    }

}
