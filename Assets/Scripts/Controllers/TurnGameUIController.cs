using UnityEngine;
using UnityEngine.UI;

public class TurnGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;
    [SerializeField] Button _playerEndTurnBtn = null;
    [SerializeField] GameObject _winScreen = null;
    [SerializeField] GameObject _loseScreen = null;

    private void OnEnable()
    {
        EnemyTurnGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded += OnEnemyTurnEnded;
        TurnGameWinState.GameWin += OnVictory;
        TurnGameLoseState.GameLose += OnDefeat;
    }

    private void OnDisable()
    {
        EnemyTurnGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
        TurnGameWinState.GameWin -= OnVictory;
        TurnGameLoseState.GameLose -= OnDefeat;
    }

    void Start()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
        _playerEndTurnBtn.interactable = true;
    }

    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
        _playerEndTurnBtn.interactable = false;
    }

    void OnEnemyTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
        _playerEndTurnBtn.interactable = true;
    }

    void OnVictory()
    {
        _winScreen.SetActive(true);
    }

    void OnDefeat()
    {
        _loseScreen.SetActive(true);
    }
}
