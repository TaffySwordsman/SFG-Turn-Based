using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSM : StateMachine
{
    [SerializeField] private string characterName;
    [SerializeField] private GameObject weaponEquipped;
    [SerializeField] private GameObject weaponUnequipped;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    protected int maxHealth {get; private set;}
    protected int currentHealth {get; private set;}

    void SetupSM()
    {
        SetupCharacter();
        ChangeState<CharacterIdleState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupCharacter()
    {
        maxHealth = _maxHealth;
        currentHealth = _currentHealth;
        Debug.Log("Creating " + characterName + " with " + _currentHealth + " health.");
    }

    public void EquipWeapon()
    {
        weaponEquipped.SetActive(true);
        weaponUnequipped.SetActive(false);
    }

    public void UnequipWeapon()
    {
        weaponEquipped.SetActive(false);
        weaponUnequipped.SetActive(true);
    }
}
