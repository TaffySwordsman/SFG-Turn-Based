using UnityEngine;

[RequireComponent(typeof(TurnGameSM))]
public class TurnGameState : State
{
    protected TurnGameSM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<TurnGameSM>();
    }
}
