using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : TurnGameState
{
    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;
    public static event Action PlayerMovesExhausted;

    [SerializeField] Text _playerTurnTextUI = null;
    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        NextPlayer();
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        Debug.Log("Player Turn: Exiting...");
        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        Debug.Log("Attempt to enter Enemy State!");

        // Enemy Calculations
        if (_playerTurnCount > 2)
        {
            int randInt = UnityEngine.Random.Range(0, 10);
            if (randInt > 5)
                StateMachine.ChangeState<TurnGameWinState>();
            else
                StateMachine.ChangeState<TurnGameLoseState>();
        }
        else
        {
            // change enemy turn state
            StateMachine.ChangeState<EnemyTurnGameState>();
        }
    }
    public void EndPlayerTurn()
    {
        OnPressedConfirm();
    }

    public void NextPlayer()
    {
        if (PlayerManager.Instance.currentActor == null)
        { 
            PlayerManager.Instance.currentActor = StateMachine.PlayerCharacters[0]; 
            PlayerManager.Instance.SelectActor(StateMachine.PlayerCharacters[0]);
        }
        else if (PlayerManager.Instance.currentActor == StateMachine.PlayerCharacters[0])
        { 
            PlayerManager.Instance.currentActor = StateMachine.PlayerCharacters[1]; 
            PlayerManager.Instance.DeselectActor(StateMachine.PlayerCharacters[0]);
            PlayerManager.Instance.SelectActor(StateMachine.PlayerCharacters[1]);
        }
        else if (PlayerManager.Instance.currentActor == StateMachine.PlayerCharacters[1])
        { 
            PlayerManager.Instance.currentActor = StateMachine.PlayerCharacters[2];
            PlayerManager.Instance.DeselectActor(StateMachine.PlayerCharacters[1]);
            PlayerManager.Instance.SelectActor(StateMachine.PlayerCharacters[2]);
        }
        else if (PlayerManager.Instance.currentActor == StateMachine.PlayerCharacters[2])
        {
            PlayerManager.Instance.DeselectActor(StateMachine.PlayerCharacters[2]);
            PlayerManager.Instance.ResetTargets();
            PlayerMovesExhausted.Invoke();
        }

    }
}
