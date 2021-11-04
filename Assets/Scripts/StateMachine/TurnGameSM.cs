using UnityEngine;

public class TurnGameSM : StateMachine
{
    [SerializeField] InputController _input;
    public InputController Input => _input;
    
    void Start()
    {
        ChangeState<SetupTurnGameState>();
    }
}