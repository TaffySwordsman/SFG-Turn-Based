using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour
{
    [SerializeField] SpriteRenderer cursor;
    [SerializeField] Color hoverColor;
    [SerializeField] Color selectedColor;
    public bool isSelected;

    private void OnEnable()
    {
        EnemyTurnGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    void Start()
    {
        cursor.gameObject.SetActive(false);
    }

    public void Hovering(bool value)
    {
        if (!isSelected)
            cursor.gameObject.SetActive(value);
    }

    public void SelectCharacter(bool selected)
    {
        isSelected = selected;
        if (selected)
        {
            cursor.color = selectedColor;
            cursor.gameObject.SetActive(true);
        }
        else
        {
            cursor.color = hoverColor;
            cursor.gameObject.SetActive(false);
        }
    }

    void OnEnemyTurnBegan()
    {
        // cursor.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnded()
    {
        // cursor.gameObject.SetActive(false);
    }
}
