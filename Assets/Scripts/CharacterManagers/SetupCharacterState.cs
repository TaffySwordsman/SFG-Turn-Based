using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCharacterState : CharacterState
{
    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        
        // Don't use ChangeState while still in Exit/Enter transition
        _activated = false;
    }

    public override void Tick()
    {
        // Would usually have delays or Input
        if(!_activated)
        {
            _activated = true;
            // StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}
