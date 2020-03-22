using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public HealthBar healthBar;
    public int playerHealthPoints;
    public ShieldBar shieldBar;
    public int playerShieldPoints;
    public int playerMaxShieldPoints;
    public string shieldElement;
   

    void Start() 
    {
        playerHealthPoints = 100;
        playerShieldPoints = 0;
        playerMaxShieldPoints = 0;
        shieldElement = "";
        healthBar.SetMaxHealth(playerHealthPoints);
        healthBar.SetHealth(playerHealthPoints);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(playerHealthPoints);
        shieldBar.SetNewShield(playerMaxShieldPoints, shieldElement);
        shieldBar.SetShield(playerShieldPoints);
    }
}
