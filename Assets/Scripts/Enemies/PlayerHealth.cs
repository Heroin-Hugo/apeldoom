using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth;
    [SerializeField] private float currentHealth;

    [Header("UI")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Animator hurtBorder;

    [Header("Death")]
    [SerializeField] private GunParent[] objectsToDisable;

    [Header("Healing")]
    [SerializeField] private Animator healBorder;
    [SerializeField] private AudioSource healSound;

    private int activate = Animator.StringToHash("Activate");
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        hurtBorder.SetTrigger(activate);
        if (currentHealth < 0) Die();
    }

    private void Update()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void Heal(float health)
    {
        if(healBorder != null) healBorder.SetTrigger(activate);
        if (healSound != null) healSound.Play();

        currentHealth += health;
    }

    private void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerScriptsManager.instance.DisableControls();


        gameOverScreen.SetActive(true);
        foreach (var obj in objectsToDisable) obj.PlayerDeath();
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
