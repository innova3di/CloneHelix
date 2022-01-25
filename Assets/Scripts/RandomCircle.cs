using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloneHelix
{
    public class RandomCircle : MonoBehaviour
    {
        public GameObject[] prefabCircle;
        public Button nextLevelButton;
        public Button mainMenuButton;

        private void Awake()
        {
            //if (instance == null)
            //    instance = this;
        }
        // Update is called once per frame
        private void Start()
        {
            InstantiatePrefabCircle();
            Button btnNextLevel = nextLevelButton.GetComponent<Button>();
            Button btnMainMenu = mainMenuButton.GetComponent<Button>();
            btnNextLevel.onClick.AddListener(InstantiatePrefabCircle);
            btnMainMenu.onClick.AddListener(InstantiatePrefabCircle);
        }

        public void InstantiatePrefabCircle()
        {
            int prefabValue = Random.Range(0, prefabCircle.Length);
            GameObject prefabClone = Instantiate(prefabCircle[prefabValue], transform.position, transform.rotation);
            prefabClone.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            prefabClone.transform.parent = gameObject.transform;
            prefabClone.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
