using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{

    private int maxHealth = 100;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    public Slider healthBar;

    public enum adjustmentType { 
        Heal, Damage
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set Player health
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        
    }

    public void updateHealth() { currentHealth = (int)healthBar.value; }



    /*
    //method to change Health
    void updateHealth(int amount, adjustmentType type) {

        switch (type)
        {

            case adjustmentType.Damage:
                //check to make sure player isn't taking more damage than they can handle
                if (currentHealth - amount < 0) { amount = currentHealth; }

                //Update Current Health
                currentHealth -= amount;
                healthBar.value = currentHealth;
                break;

            case adjustmentType.Heal:
                //check to make sure player isn't healing more than they can handle
                if (currentHealth + amount > maxHealth) { amount = maxHealth - currentHealth; }

                //Update Current Health
                currentHealth += amount;
                healthBar.value = currentHealth;
                break;

        }
    }*/

}
