using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    public Transform stageUIGroup;
    public GameObject stageUIPrefab;
    public int numberStages;

    private MainMenu mainMenu;

    void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        for (int i = 0; i < numberStages; i++)
        {
            var o = Instantiate(stageUIPrefab, stageUIGroup).GetComponent<Button>();
            o.onClick.AddListener(() =>
            {
                string str = o.GetComponentInChildren<Text>().text;
                int stage = str[str.Length - 1] - 48;
                mainMenu.SelectStage(stage);
            });
            o.GetComponentInChildren<Text>().text = "Stage " + (i + 1);
        }
    }
}
