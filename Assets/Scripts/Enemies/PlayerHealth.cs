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

    [Header("Death")]
    [SerializeField] private GunParent[] objectsToDisable;


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        if (currentHealth < 0) Die();
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
