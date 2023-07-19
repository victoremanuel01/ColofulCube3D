using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] seta = new GameObject[2];
    public Button pause;
    public GameObject vfx;
    public bool inputLeft = false;
    public bool tutorialOn = true;
    public static Tutorial tutorial;

    public void Awake()
    {
        if(tutorial == null)
        {
            tutorial = this;
        }else
        if(tutorial != null){
            Destroy(this);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        if(tutorialOn == true)
        {
            pause.interactable = false;
        }
    }

    public void ActiveLeft()
    {
        inputLeft = true;
        if(seta[0] != null)
        {
            Destroy(seta[0]);
            seta[1].SetActive(true);
        }
    }

    public void DontActiveTutorialOn()
    {
        tutorialOn = false;
        if(seta[1] != null)
        Destroy(seta[1]);
        if(vfx != null)
        vfx.SetActive(true);
        if(pause != null)
        pause.interactable = true;
    }
}
