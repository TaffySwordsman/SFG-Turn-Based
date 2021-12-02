using UnityEngine;
using UnityEngine.UI;

public class TurnGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;
    [SerializeField] Button _playerEndTurnBtn = null;
    [SerializeField] GameObject _winScreen = null;
    [SerializeField] GameObject _loseScreen = null;
    [SerializeField] TurnGameSM turnGameSM;
    [SerializeField] Slider[] playerHealths;
    [SerializeField] Slider[] enemyHealths;

    private void OnEnable()
    {
        EnemyTurnGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded += OnEnemyTurnEnded;
        TurnGameWinState.GameWin += OnVictory;
        TurnGameLoseState.GameLose += OnDefeat;
        PlayerTurnGameState.PlayerMovesExhausted += OnPlayerMovesExhausted;
    }

    private void OnDisable()
    {
        EnemyTurnGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
        TurnGameWinState.GameWin -= OnVictory;
        TurnGameLoseState.GameLose -= OnDefeat;
        PlayerTurnGameState.PlayerMovesExhausted -= OnPlayerMovesExhausted;

        foreach (CharacterSM playerSM in turnGameSM.PlayerCharacters)
        { playerSM.OnHealthChanged -= UpdatePlayerHealth; }

        foreach (CharacterSM enemySM in turnGameSM.EnemyCharacters)
        { enemySM.OnHealthChanged -= UpdateEnemyHealth; }
    }

    void Start()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
        _playerEndTurnBtn.interactable = false;

        foreach (CharacterSM playerSM in turnGameSM.PlayerCharacters)
        { playerSM.OnHealthChanged += UpdatePlayerHealth; }

        foreach (CharacterSM enemySM in turnGameSM.EnemyCharacters)
        { enemySM.OnHealthChanged += UpdateEnemyHealth; }
    }

    private void UpdatePlayerHealth()
    {
        playerHealths[0].value = Mathf.InverseLerp(0, turnGameSM.PlayerCharacters[0].maxHealth, turnGameSM.PlayerCharacters[0].currentHealth); 
        playerHealths[1].value = Mathf.InverseLerp(0, turnGameSM.PlayerCharacters[1].maxHealth, turnGameSM.PlayerCharacters[1].currentHealth); 
        playerHealths[2].value = Mathf.InverseLerp(0, turnGameSM.PlayerCharacters[2].maxHealth, turnGameSM.PlayerCharacters[2].currentHealth); 
    }

    private void UpdateEnemyHealth()
    {
        enemyHealths[0].value = Mathf.InverseLerp(0, turnGameSM.EnemyCharacters[0].maxHealth, turnGameSM.EnemyCharacters[0].currentHealth); 
        enemyHealths[1].value = Mathf.InverseLerp(0, turnGameSM.EnemyCharacters[1].maxHealth, turnGameSM.EnemyCharacters[1].currentHealth); 
        enemyHealths[2].value = Mathf.InverseLerp(0, turnGameSM.EnemyCharacters[2].maxHealth, turnGameSM.EnemyCharacters[2].currentHealth);
    }

    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
        _playerEndTurnBtn.interactable = false;
    }

    void OnEnemyTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
        // _playerEndTurnBtn.interactable = true;
    }

    void OnPlayerMovesExhausted()
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
