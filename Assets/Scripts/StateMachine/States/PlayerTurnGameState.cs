using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : TurnGameState
{
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
            int randInt = Random.Range(0, 10);
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
}
