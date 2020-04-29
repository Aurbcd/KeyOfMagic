using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public HealthBar healthBar;
    public CanvasGroup canvasGHealthBar;
    public static int playerHealthPoints;   
    public ShieldBar shieldBar;
    public static int playerShieldPoints;
    public static int playerMaxHeathPointsInitial = 200;
    public static int playerMaxHeathPoints;
    public static bool IsDead;
    public static int playerMaxShieldPoints;
    public static string shieldElement;
    public static float Difficulte = 1.5f;
    public static int niveau;
    //mécaniques item
    public static float DamageMultiplier; //Aucun est en pourcentage
    public static float volDeVie;
    public static float shieldMultiplier;
    public static float resistanceMultiplier;
    private bool amHero = false;
    private bool trouve;
    private Animator mAnimator;
    public static AudioClip GameOverAudio;
    public static AudioClip shieldBroken;
    public AudioMixerGroup soundEffectNotif;
    public AudioMixerGroup soundEffectPlayer;
    //XmlManager
    private GameObject XmlManager;

    // Start is called before the first frame update
    void Start()
    {
        XmlManager = GameObject.Find("XmlManager");
        IsDead = false;
        GameOverAudio = Resources.Load<AudioClip>("GameOver");
        shieldBroken = Resources.Load<AudioClip>("ShieldBroken");
        mAnimator = GetComponent<Animator>();
        healthBar.SetMaxHealth(playerMaxHeathPoints);
        healthBar.SetHealth(playerHealthPoints);
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
        if(playerHealthPoints > playerMaxHeathPoints)
        {
            playerHealthPoints = playerMaxHeathPoints;
        }
        foreach (ItemInterface item in InventaireScript.items)
        {
            trouve = false;
            if (item.Nom.Equals("Habits de Héros"))
            {
                amHero = true;
                trouve = true;
            }
        }
        if(!trouve)
        {
            amHero = false;
        }

        if (playerHealthPoints <= 0 && !IsDead)
        {
            IsDead = true;
            mAnimator.SetBool("IsDead",true);
            mAnimator.Play("OnYourWayToDie");
        }
    }

    public void GameOverEvent()
    {
        Invoke("GameOver", 2f);
        foreach (ItemInterface item in InventaireScript.items)
        {
            item.Jete();
        }
        InventaireScript.items.Clear();
        InventaireScript.itemsRencontres.Clear();
    }
    public void GameOverSound()
    {
        GetComponent<AudioSource>().outputAudioMixerGroup = soundEffectNotif;
        GetComponent<AudioSource>().PlayOneShot(GameOverAudio);
    }

    public void GameOver()
    {
        RoomManager.PoolD1.Clear();
        RoomManager.PoolD2.Clear();
        RoomManager.PoolD3.Clear();
        RoomManager.PoolG1.Clear();
        RoomManager.PoolG2.Clear();
        RoomManager.PoolG3.Clear();
        ImprovedSpellInput.spellListStorage.Clear();
        //Enigmes
        EngimeChasseur.compteur = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void DamagePlayer(int damage, string attackElement){
        if (shieldElement == "")
        {
            playerHealthPoints -= (int)(damage * resistanceMultiplier);
        }
        else
        {
            int scaledDamage = 0;

            //Application des éléments
            if (XmlManager.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == shieldElement).weakness == attackElement)
            {
                scaledDamage = (int) (2*damage);
                Debug.Log( attackElement + " est très efficace contre " + shieldElement);
            }
            else if (XmlManager.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == shieldElement).resistance == attackElement)
            {
                scaledDamage = (int) (0.5*damage);
                Debug.Log(attackElement + " est pas efficace contre " + shieldElement);
            }
            else
            {
                scaledDamage = damage;
                Debug.Log("Neutre");
            }

            if (playerShieldPoints > 0 && (playerShieldPoints - scaledDamage) < 0)
            {
                GetComponent<AudioSource>().outputAudioMixerGroup = soundEffectPlayer;
                GetComponent<AudioSource>().PlayOneShot(shieldBroken, 0.5f);

            }

            //Application des dégâts et/ou au shield
            if ( (playerShieldPoints - scaledDamage) >0 )
            {
                playerShieldPoints -= scaledDamage;
                if (amHero)
                {
                    playerShieldPoints = 0;
                }
            }
            else
            {
                playerShieldPoints = 0;
                playerHealthPoints -= (scaledDamage - playerShieldPoints);
            }
        }
    }
}
