using UnityEngine;
using System;

public class TurnGameLoseState : TurnGameState
{
    public static event Action GameLose;

    public override void Enter()
    {
        Debug.Log("Defeat: ...Entering");
        GameLose?.Invoke();
    }

    public override void Exit()
    {
        Debug.Log("Defeat: Exit...");
    }
}
