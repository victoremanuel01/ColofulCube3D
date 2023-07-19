using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public Button[] level = new Button[3];
    public bool[] niveis = new bool[3];

    void Awake()
    {
        for(int i = 0; i < level.Length; i++)
        {
            niveis[i] = false;
        }
    }
    void Start()
    {
        if(PlayerPrefs.GetInt("Fase2") >= 1)
        {
            niveis[0] = true;
            Debug.Log("Fase1 -" + PlayerPrefs.GetInt("Fase2")+ niveis[0]);
            Debug.Log("Fase2 -" + PlayerPrefs.GetInt("Fase3")+ niveis[1]);
            Debug.Log("Fase3 -" + PlayerPrefs.GetInt("Fase4")+ niveis[2]);
        }
        if(PlayerPrefs.GetInt("Fase3") >= 1)
        {
            niveis[1] = true;
        }
        if(PlayerPrefs.GetInt("Fase4") >= 1)
        {
            niveis[2] = true;
        }

        for(int i = 0; i < level.Length; i++)
        {
            level[i].interactable = niveis[i];
        }
        
    }
}
