using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : BaseStats
{
    public EnemyStats()
    {
        className = "Enemy";
        maxHealth = 50;
        health = 50;
        strength = 50;
        defense = 50;
    }
}
