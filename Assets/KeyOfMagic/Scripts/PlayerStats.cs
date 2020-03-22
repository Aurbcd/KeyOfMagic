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
    public static int playerMaxHeathPoints;
    public int playerMaxShieldPoints;
    public static string shieldElement;
    public static float Difficulte;

    void Start() 
    {
        playerMaxHeathPoints = 1000;
        playerHealthPoints = 100;
        playerShieldPoints = 0;
        playerMaxShieldPoints = 0;
        shieldElement = "";
        healthBar.SetMaxHealth(playerMaxHeathPoints);
        healthBar.SetHealth(playerHealthPoints);
        Difficulte = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetMaxHealth(playerMaxHeathPoints);
        healthBar.SetHealth(playerHealthPoints);
        shieldBar.SetNewShield(playerMaxShieldPoints, shieldElement);
        shieldBar.SetShield(playerShieldPoints);
        if (playerShieldPoints <= 0)
        {
            shieldElement = "";
        }
    }

    public void DamagePlayer(int damage, string attackElement){
        if (shieldElement == "")
        {
            playerHealthPoints -= damage;
        }
        else
        {
            int scaledDamage = 0;

            //Application des éléments
            if (this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == shieldElement).weakness == attackElement)
            {
                scaledDamage = (int) (2*damage);
                Debug.Log( attackElement + " est très efficace contre " + shieldElement);
            }
            else if (this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == shieldElement).resistance == attackElement)
            {
                scaledDamage = (int) (0.5*damage);
                Debug.Log(attackElement + " est pas efficace contre " + shieldElement);
            }
            else
            {
                scaledDamage = damage;
                Debug.Log("Neutre");
            }

            //Application des dégâts et/ou au shield
            if ( (playerShieldPoints - scaledDamage) >0 )
            {
                playerShieldPoints -= scaledDamage;
            }
            else
            {
                playerShieldPoints = 0;
                playerHealthPoints -= (scaledDamage - playerShieldPoints);
            }
        }
    }
}
