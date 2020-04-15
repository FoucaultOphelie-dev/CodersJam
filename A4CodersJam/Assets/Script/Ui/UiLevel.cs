using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLevel : MonoBehaviour
{
    public GameObject playButton;
    public bool playIsActive;

    public GameObject quitButton;
    public bool quitIsActive;

    private void Awake()
    {
        quitIsActive = false;
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.I) & quitIsActive == true)
        {
            quitButton.SetActive(false);
            quitIsActive = false;
        }
        else if(Input.GetKeyDown(KeyCode.I) & quitIsActive == false)
        {
            quitButton.SetActive(true);
            quitIsActive = true;
        }
    }
}
