using System;
using UnityEngine;

public class CharacterSM : StateMachine
{
    [SerializeField] private string characterName;
    [SerializeField] private GameObject weaponEquipped;
    [SerializeField] private GameObject weaponUnequipped;
    [SerializeField] private CharacterUIController uiController;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    protected int maxHealth { get; private set; }
    protected int currentHealth { get; private set; }
    protected Animator animator { get; private set; }
    public bool boosted = false;
    public event Action OnHoverStart;
    public event Action OnHoverEnd;
    private bool mouseHover;
    public bool MouseHover
    {
        get { return mouseHover; }
        set
        {
            if (value == mouseHover) return;
            mouseHover = value;

            Hovering(value);
        }
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(mouseHover && Input.GetMouseButtonDown(0))
            uiController.SelectCharacter(true);
        if(Input.GetKeyDown(KeyCode.A))
            animator.SetTrigger("Primary");
        if(Input.GetKeyDown(KeyCode.S))
            animator.SetTrigger("Secondary");
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Over: " + characterName);
        mouseHover = true;
        uiController.Hovering(true);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exited: " + characterName);
        mouseHover = false;
        uiController.Hovering(false);
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

    protected void Hovering(bool value)
    {

    }

    public void Heal()
    {

    }

    public void TakeDamage()
    {

    }
}
