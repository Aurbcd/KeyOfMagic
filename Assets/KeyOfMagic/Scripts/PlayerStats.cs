using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHealthPoints;
    public int playerShieldPoints;
    public string ShieldElement;

    void Start() 
    {
        playerHealthPoints = 100;
        playerShieldPoints = 0;
        ShieldElement = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
