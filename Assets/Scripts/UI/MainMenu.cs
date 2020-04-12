using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EnterSingleplay()
    {
        GameManager.Instance.gamemode = GameMode.SINGLE;
    }

    public void EnterMultiplay()
    {
        GameManager.Instance.gamemode = GameMode.MULTI;
    }
    public void EnterLAN()
    {
        GameManager.Instance.gamemode = GameMode.LAN;
    }

    public void SelectStage(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
