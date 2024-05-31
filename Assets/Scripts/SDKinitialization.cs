using System;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.CloudCode;
using Unity.Services.Core;
using UnityEngine;

public class SDKinitialization : MonoBehaviour
{
    private class CloudCodeResponse
    {
        public string welcomeMessage;
    }

    async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public async void ButtonFunc()
    {
        Debug.Log("in func");
        var arguments = new Dictionary<string, object> { { "name", "Unity" } };
        var response = await CloudCodeService.Instance.CallEndpointAsync<CloudCodeResponse>("testservice", arguments);
        
        Debug.Log(response.welcomeMessage);
    }
}