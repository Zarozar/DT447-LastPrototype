using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.CloudCode;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class LoginManager : MonoBehaviour
{
    private class CloudCodeResponse
    {
        public string welcomeMessage;
    }

    

    [SerializeField]
    private TMP_InputField Username_IF;

    [SerializeField]
    private TMP_InputField Password_IF;

    private string Username_str = "";
    private string Password_str = "";

    private UIManager uIManager;
    
    //0 = login, 1 = signup
    private int authen_option = 0;



    async void Awake()
    {
        try
        {
            uIManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        try
        {
            await UnityServices.InitializeAsync();
            //Debug.Log("Username " + Username_str);
            //await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(Username_str, Password_str);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void Update()
    {
        if (!Username_IF.IsActive())
        {
            Username_IF.text = "";
            Password_IF.text = "";
        }
    }

    public void AuthenProcedure()
    {
        Username_str = Username_IF.text;
        Password_str = Password_IF.text;

        Debug.Log("Username: " + Username_str);
        Debug.Log("Password: " + Password_str);

        if (authen_option == 0)
        {
            Debug.Log("Login");
            Task task = SignInWithUsernamePasswordAsync(Username_str, Password_str);
        }
        else
        {
            Debug.Log("SignUp");
            Task task = SignUpWithUsernamePasswordAsync(Username_str, Password_str);
        }   
    }
     
     private async Task SignInWithUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            
            Debug.Log("SignIn is successful.");
            uIManager.HideLoginUI();
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        WelcomeCode(username);
    }


    private async Task SignUpWithUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            
            Debug.Log("SignUp is successful.");
            uIManager.HideLoginUI();

        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    public void SetloginBool(int status)
    { 
        authen_option = status;
    }

    public async void WelcomeCode(string usrN)
    {
        //Debug.Log("in func");
        var arguments = new Dictionary<string, object> { { "name", usrN } };
        var response = await CloudCodeService.Instance.CallEndpointAsync<CloudCodeResponse>("testservice", arguments);

        Debug.Log(response.welcomeMessage);
    }

    
}
