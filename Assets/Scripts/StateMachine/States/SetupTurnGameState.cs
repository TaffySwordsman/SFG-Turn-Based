using UnityEngine;

public class SetupTurnGameState : TurnGameState
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
        if (!_activated)
        {
            _activated = true;

            // Set up players and enemies
            
            Debug.Log("Setup: Setting up enemies");
            foreach (CharacterSM enemySM in StateMachine.EnemyCharacters)
            {
                enemySM.SetupSM();
            }
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}