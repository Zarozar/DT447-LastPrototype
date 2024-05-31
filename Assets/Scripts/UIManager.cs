using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ChoiceInterface;

    [SerializeField]
    private GameObject AuthenUIObj;

    [SerializeField]
    private LoginManager loginManager;

    [SerializeField]
    private UnityEngine.UI.Button LoginButton;

    [SerializeField]
    private GameObject RollButton;

    public void LoginUI()
    { 
        ChoiceInterface.SetActive(false);
        AuthenUIObj.SetActive(true);
        loginManager.SetloginBool(0);
        LoginButton.GetComponentInChildren<TextMeshProUGUI>().text = "Login";
    }

    public void SignUpUI()
    {
        ChoiceInterface.SetActive(false);
        AuthenUIObj.SetActive(true);
        loginManager.SetloginBool(1);
        LoginButton.GetComponentInChildren<TextMeshProUGUI>().text = "SignUp";
    }

    public void Back()
    {
        ChoiceInterface.SetActive(true);
        AuthenUIObj.SetActive(false);

    }

    public void HideLoginUI()
    {
        ChoiceInterface.SetActive(false);
        AuthenUIObj.SetActive(false);
        RollButton.SetActive(true);
    }


}
