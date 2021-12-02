using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    public static PlayerManager Instance { get { return _instance; } }
    public CharacterSM currentActor;
    public CharacterSM currentTarget;
    PlayerTurnGameState playerTurnGameState;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        playerTurnGameState = FindObjectOfType<PlayerTurnGameState>();
    }

    public void ResetTargets()
    {
        currentActor = null;
        currentTarget = null;
    }

    public void SelectActor(CharacterSM actor)
    {
        actor.SelectCharacter(true);
    }

    public void DeselectActor(CharacterSM actor)
    {
        actor.SelectCharacter(false);
    }

    public void NextPlayer()
    {
        playerTurnGameState.NextPlayer();
    }
}
