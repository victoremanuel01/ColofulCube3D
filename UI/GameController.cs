using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{       
    [Header("Pré-Lobby")]
    public AudioSource music;
    public GameObject preLobby;
    public GameObject lobby;
    public TextMeshProUGUI touchContinue;
    [Header("Lobby")]
    public GameObject optsButton;
    public GameObject[] levels;

    public void Start()
    {
        if(GameManager.manager.openMenu == false)
        {
            preLobby.SetActive(true);
            lobby.SetActive(false);
        }else
        {
            preLobby.SetActive(false);
            lobby.SetActive(true);
        }
    }
    
    public void CarregarCena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        touchContinue.enabled = Mathf.PingPong(Time.time, 0.5f) > 0.25f;
    }

    public void Options()
    {
     optsButton.SetActive(true);
     Time.timeScale = 0f;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void ExitOptions()
    {
        optsButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ButtonPreLobby()
    {
        int tutorial = PlayerPrefs.GetInt("Tutorial");
        if(tutorial == 1)
        {
            lobby.SetActive(true);
            preLobby.SetActive(false);
            GameManager.manager.openMenu = true;
            music.volume = 0.14f;
        }else
        {
            SceneManager.LoadScene("Fase1");
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        
    }

    public void StarsLobby(string Stars)
    {
        int stars = PlayerPrefs.GetInt(Stars);
        Debug.Log(PlayerPrefs.GetInt(Stars));
    }



}
