using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ative : MonoBehaviour
{
    public GameObject trap;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            trap.SetActive(true);
        }
    }
}
