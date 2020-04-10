using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    //public static System.Action Trigger;

    public GameObject nextBtn;

    private int next;
    private void OnEnable()
    {
        if (GameManager.Instance.gamemode == GameMode.SINGLE)
        {
            next = SceneManager.GetActiveScene().buildIndex + 1;
            nextBtn.SetActive(next <= GameManager.Instance.numberStages);
        }
        else
        {
            nextBtn.SetActive(false);
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(next);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    //private void Awake()
    //{
    //    Trigger += Active;
    //}

    //private void OnDestroy()
    //{
    //    Trigger -= Active;
    //}

    //private void Active() => gameObject.SetActive(true);
}
