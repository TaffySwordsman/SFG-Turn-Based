using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : CharacterManager
{
    [SerializeField] int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
