using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BotteDeVoyage : MonoBehaviour, ItemInterface
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description_affiché;
    public TextMeshProUGUI lore_affiché;
    private bool isDisplayed;
    private float fadeSpeed = 5f;
    public string Nom
    {
        get
        {
            return "Botte de Voyage";
        }
    }

    public int Type
    {
        get
        {
            return 4;
        }
    }

    public string description
    {
        get
        {
            return "<sprite=0>  Augmente la vitesse de déplacement";
        }
    }
    public string lore
    {
        get
        {
            return "\" Le cuir de ces bottes proviendrait d'une race d'herbivores aujourd'hui éteinte, qui confèrerait des immenses pouvoir à celui ou celle capable de prononcer leur nom. Dommage que tous les livres sur cette époque soient partis en fumée dans le Grand Incendie du Havre de la nuit.\"";
        }
    }

    public int rarete
    {
        get
        {
            return 0;
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void Ramasse()
    {
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed +=2;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed -= 2;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;

    }

    public void Update()
    {
        if (isDisplayed)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, fadeSpeed * Time.deltaTime);
        }
        else
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void OnMouseOver()
    {
        isDisplayed = true;
    }

    void OnMouseExit()
    {
        isDisplayed = false;
    }
}
