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
    protected Animator animator { get; private set; }

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void SetupSM()
    {
        SetupCharacter();
        // ChangeState<CharacterIdleState>();
    }

    void SetupCharacter()
    {
        maxHealth = _maxHealth;
        currentHealth = _currentHealth;
        Debug.Log("Creating " + characterName + " with " + _currentHealth + " health.");
        animator.SetTrigger("DrawWeapon");
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
