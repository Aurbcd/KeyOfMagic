using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public HealthBar healthBar;
    public CanvasGroup canvasGHealthBar;
    public static int playerHealthPoints;
    public ShieldBar shieldBar;
    public static int playerShieldPoints;
    public int playerMaxShieldPoints;
    public static string shieldElement;
    public static float Difficulte;

    void Start() 
    {
        playerHealthPoints = 100;
        playerShieldPoints = 0;
        playerMaxShieldPoints = 0;
        shieldElement = "";
        healthBar.SetMaxHealth(playerHealthPoints);
        healthBar.SetHealth(playerHealthPoints);
        Difficulte = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(playerHealthPoints);
        shieldBar.SetNewShield(playerMaxShieldPoints, shieldElement);
        shieldBar.SetShield(playerShieldPoints);
    }
}
