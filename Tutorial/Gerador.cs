using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject objeto;

    public void Start()
    {
        if(Tutorial.tutorial.tutorialOn == true){
        InvokeRepeating(nameof(Invocador), 0f, 1f);
        }
        Debug.Log(Tutorial.tutorial.tutorialOn);
    }

    public void Invocador()
    {
        Instantiate(objeto, transform.position, transform.rotation);

    }

}
