using UnityEngine;
using System;

public class TurnGameWinState : TurnGameState
{
    public static event Action GameWin;

    public override void Enter()
    {
        Debug.Log("Victory: ...Entering");
        GameWin?.Invoke();
    }

    public override void Exit()
    {
        Debug.Log("Victory: Exit...");
    }
}
