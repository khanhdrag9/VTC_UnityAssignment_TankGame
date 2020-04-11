using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineScreen : MonoBehaviour
{
    public InputField inputField;
    public Button findBtn;
    public GameObject findingScreen;

    void Update()
    {
        findBtn.interactable = inputField.text.Trim().Length > 0;
    }

    public void Find()
    {
        OnlineSystem.Instance.playerName = inputField.text.Trim();
        OnlineSystem.Instance.Find();
    }

    private void Start()
    {
        OnlineSystem.Instance.OnConnectResult += CheckResult;
    }

    private void OnDestroy()
    {
        OnlineSystem.Instance.OnConnectResult -= CheckResult;
    }

    private void CheckResult(bool result)
    {
        findingScreen.SetActive(false);
    }
}
