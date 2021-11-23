using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float startingHealth = 100;

    public float currentHealth;

    public TriggerWinningController triggerWinningController;

    public Healthbar healthBar;


	// Use this for initialization
	void Start () {
        this.ResetHealthToStarting();

	}

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    
    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Update() {
        if (currentHealth <= 0)
        {
            triggerWinningController.CaughtPlayer();
        }
    }
}
