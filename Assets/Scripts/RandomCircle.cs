using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloneHelix
{
    public class RandomCircle : MonoBehaviour
    {
        public static RandomCircle instance;
        public GameObject[] prefabCircle;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        // Update is called once per frame
        private void Start()
        {
            InstantiatePrefabCircle();
        }

        private void Update()
        {
            if(GameManager.instance.changeLevel == true && Input.GetMouseButtonUp(0))
            {
                InstantiatePrefabCircle();
            }
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
