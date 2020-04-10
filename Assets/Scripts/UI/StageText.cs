using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StageText : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Stage " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }
}
