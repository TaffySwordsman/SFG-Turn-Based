using System;
using UnityEngine;

public class CharacterSM : MonoBehaviour
{
    [SerializeField] private string characterName;
    [SerializeField] private GameObject weaponEquipped;
    [SerializeField] private GameObject weaponUnequipped;
    [SerializeField] private CharacterUIController uiController;
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    protected Animator animator { get; private set; }
    public bool boosted = false;
    public event Action OnHoverStart;
    public event Action OnHoverEnd;
    public event Action OnHealthChanged;
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

    private void Update()
    {
        if (mouseHover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (PlayerManager.Instance.currentActor == null)
                    PlayerManager.Instance.currentActor = this;
                else if (PlayerManager.Instance.currentTarget == null)
                    PlayerManager.Instance.currentTarget = this;
                else
                    return;
            }
            if(Input.GetMouseButtonDown(1))
                TakeDamage(PlayerManager.Instance.currentTarget, 20);
        }
        if (Input.GetKeyDown(KeyCode.A))
            animator.SetTrigger("Primary");
        if (Input.GetKeyDown(KeyCode.S))
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
        Debug.Log("Creating " + characterName + " with " + currentHealth + " health.");
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

    protected void SelectCharacter()
    {
        uiController.SelectCharacter(true);

    }

    protected void Hovering(bool value)
    {

    }

    public void Heal(CharacterSM target, int amount)
    {
        target.currentHealth += amount;
        target.currentHealth = Mathf.Clamp(target.currentHealth, 0, target.maxHealth);
        OnHealthChanged.Invoke();
    }

    public void TakeDamage(CharacterSM target, int amount)
    {
        target.currentHealth -= amount;
        target.currentHealth = Mathf.Clamp(target.currentHealth, 0, target.maxHealth);
        OnHealthChanged.Invoke();
    }
}
