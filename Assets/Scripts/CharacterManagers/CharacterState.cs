using UnityEngine;

[RequireComponent(typeof(CharacterSM))]
public class CharacterState : State
{
    protected CharacterSM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<CharacterSM>();
    }
}
