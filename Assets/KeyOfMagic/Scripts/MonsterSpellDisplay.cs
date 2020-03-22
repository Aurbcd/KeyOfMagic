using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpellDisplay : MonoBehaviour
{
    public Text displayText;
    public string hexcolor;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        string element = GetComponent<AI_SlimeRouge>().element;
        if (this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == element) != null)
        {
          hexcolor = this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == element).hexColor;
          Debug.Log(hexcolor);
          if (GetComponent<AI_SlimeRouge>().affichage != null)
          {
              displayText.text = "<color=" + hexcolor + ">" + GetComponent<AI_SlimeRouge>().affichage + "</color>";
              Debug.Log("<color=" + hexcolor + ">" + GetComponent<AI_SlimeRouge>().affichage + "</color>");
          }
        }
    }
}
