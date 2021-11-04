using UnityEngine;

public class SetupTurnGameState : TurnGameState
{
    [SerializeField] int _playerHealth = 10;
    [SerializeField] int _enemyHealth = 10;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Creating players with " + _playerHealth + " health.");
        Debug.Log("Creating enemies with " + _enemyHealth + " health.");
        
        // Don't use ChangeState while still in Exit/Enter transition
        _activated = false;
    }

    public override void Tick()
    {
        // Would usually have delays or Input
        if(!_activated)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}