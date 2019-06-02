using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[AlwaysUpdateSystem]
public class TurnSystem : ComponentSystem
{
    private bool newTurn = true;
    private bool switchTurnsOff = false;
    

    struct TurnUsingComponents
    {
        public TurnDataComponent turns;
    }
    protected override void OnUpdate()
    {

        if (switchTurnsOff)
        {
            foreach (TurnUsingComponents d in GetEntities<TurnUsingComponents>())
            {
                d.turns.newTurn = false;
            }
            switchTurnsOff = false;
        }

        if (newTurn)
        {
            foreach (TurnUsingComponents d in GetEntities<TurnUsingComponents>())
            {
                d.turns.newTurn = true;
            }
            switchTurn();
            switchTurnsOff = true;
        }
    }

    public void switchTurn()
    {        
        newTurn = !newTurn;
    }


}
