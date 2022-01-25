using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableImagePanel : MonoBehaviour
{
    private Image panelImage;
    public GameObject[] childGO;
    // Start is called before the first frame update
    void Start()
    {
        panelImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panelImage.enabled == true)
        {
            foreach (GameObject child in childGO)
            {
                child.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject child in childGO)
            {
                child.SetActive(false);
            }
        }
    }
}



