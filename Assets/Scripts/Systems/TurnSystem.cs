using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TurnSystem : ComponentSystem
{
    bool switchTurnsOff = false;

    struct TurnManagementComponents
    {
        public TurnManagerComponent turnManager;
    }

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

        foreach (TurnManagementComponents c in GetEntities<TurnManagementComponents>())
        {
            if (c.turnManager.newTurn)
            {
                foreach (TurnUsingComponents d in GetEntities<TurnUsingComponents>())
                {
                    d.turns.newTurn = true;
                }
                c.turnManager.newTurn = false;
                switchTurnsOff = true;
            }
        }
    }


}
