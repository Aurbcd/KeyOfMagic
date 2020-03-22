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
    void Awake()
    {
        ins = this;
        this.LoadItems();
    }

    //save function (create a button if you wanna use this bad boy)
    public void SaveSpells(){
        //open a new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(SpellDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/KeyOfMagic/XML/spell_data.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, SpellDatabase);
        stream.Close();
    }

    //load function
    public void LoadItems(){
        XmlSerializer serializer = new XmlSerializer(typeof(SpellDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/KeyOfMagic/XML/spell_data.xml", FileMode.Open);
        SpellDatabase = serializer.Deserialize(stream) as SpellDatabase;
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