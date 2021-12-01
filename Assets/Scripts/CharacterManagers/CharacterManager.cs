using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject weaponEquipped;
    [SerializeField] private GameObject weaponUnequipped;
    [SerializeField] private int _maxHealth;
    protected int maxHealth {get; private set;}

    void Start()
    {
        maxHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
