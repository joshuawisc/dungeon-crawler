using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats
{
    public string className;
    public int maxHealth;
    public int health;
    public int strength;
    public int defense;

    public void TakeDamage(int damage)
    {
        if (defense >= damage)
            health -= 10;
        else
            health -= (damage - defense);
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
            health = maxHealth;
    }
}
