using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
    private int NumberOfRolls;

    private void Start()
    {
        NumberOfRolls = 5;
    }

    public void DecrementRollCount()
    { 
        NumberOfRolls--;
    }

    public int GetRollCount()
    {
        return NumberOfRolls;
    }
}
