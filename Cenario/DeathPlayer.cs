using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public GameObject TenteNovamente;
    // public AudioSource som;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            ScriptCanvas.Instance.Continue();
        }
    }

    // public void Again()
    // {
    //     TenteNovamente.SetActive(true);
    //     player.Play();
    //     Time.timeScale = 0f;    
    // }
    // public void Som()
    // {
    //     som.Play();
    // }
}
