using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Services.CloudCode;
using UnityEngine;

public class ServerServices : MonoBehaviour
{

    private class RollDiceResponse
    {
        public int roll;
        public int sides;
    }

    [SerializeField]
    private TextMeshProUGUI resultsText;


    [SerializeField]
    private Playermanager Pmanager;

    public async void gachaRollFunction()
    {
        var arguments = new Dictionary<string, object> { { "NoOfRolls", Pmanager.GetRollCount() } };
        var response = await CloudCodeService.Instance.CallEndpointAsync<RollDiceResponse>("TestGachaService", arguments);

        Debug.Log("sides: " + response.sides + ", you rolled: " + response.roll );

        Pmanager.DecrementRollCount();

        resultsText.text = "sides: " + response.sides + ", you rolled: " + response.roll + " attempts left: " + Pmanager.GetRollCount();
    }
}
