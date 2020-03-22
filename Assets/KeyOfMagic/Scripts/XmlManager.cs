using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class XmlManager : MonoBehaviour
{

    //Askip c'est horrible
    public static XmlManager ins;

    //List of items
    public SpellDatabase SpellDatabase;
    public ElementDatabase ElementDatabase;
    void Awake()
    {
        ins = this;
        this.LoadSpells();
        this.LoadElements();
    }

    //save functions (create a button if you wanna use these bad boys)
    public void SaveSpells(){
        //open a new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(SpellDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/KeyOfMagic/XML/spell_data.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, SpellDatabase);
        stream.Close();
    }
    public void SaveElements()
    {
        //open a new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ElementDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/KeyOfMagic/XML/element_data.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, ElementDatabase);
        stream.Close();
    }

    //load functions (called on wake up)
    public void LoadSpells(){
        XmlSerializer serializer = new XmlSerializer(typeof(SpellDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/KeyOfMagic/XML/spell_data.xml", FileMode.Open);
        SpellDatabase = serializer.Deserialize(stream) as SpellDatabase;
        stream.Close();
    }

    public void LoadElements()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ElementDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/KeyOfMagic/XML/element_data.xml", FileMode.Open);
        ElementDatabase = serializer.Deserialize(stream) as ElementDatabase;
        stream.Close();
    }



}

[System.Serializable]
public class SpellEntry {
    public string spellName;
    public int value;
    public string element;

    public bool offensive;
}

[System.Serializable]
public class SpellDatabase {
    public  List<SpellEntry> SpellBook = new List<SpellEntry> ();
}

[System.Serializable]
public class ElementEntry
{
    public string elementName;
    public Color32 color32;
    public string hexColor;

    public string weakness;
    public string resistance;
    public string efficient;
    public string inefficient;


}

[System.Serializable]
public class ElementDatabase
{
    public List<ElementEntry> Elementdb = new List<ElementEntry>();
    //public static List<ElementEntry> Elementdbstatic =Elementdb;
}