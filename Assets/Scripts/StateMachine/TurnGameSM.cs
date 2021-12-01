using UnityEngine;

public class TurnGameSM : StateMachine
{
    [SerializeField] InputController _input;
    public InputController Input => _input;
    public CharacterSM[] PlayerCharacters;
    public CharacterSM[] EnemyCharacters;
    
    void Start()
    {
        ChangeState<SetupTurnGameState>();
    }
}