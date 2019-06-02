using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ButtonNewTurn : MonoBehaviour
{
    private TurnSystem turnSystem;

    public void Awake()
    {
        turnSystem = World.Active.GetExistingManager<TurnSystem>();
    }

    public void newTurn()
    {
        turnSystem.switchTurn();
    }
}
