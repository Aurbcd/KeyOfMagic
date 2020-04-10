using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellFromScroll : MonoBehaviour
{
    void OnMouseDown()
    {
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 9)
        {
            int spellCount = XmlManager.ins.SpellDatabase.SpellBook.Count;
            int spellIndice = 0;
            int counter = 0; //Pour savoir si on a vu tous les sorts
            System.Random rand = new System.Random();
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0]; 
            while (player.GetComponent<ImprovedSpellInput>().spellListStorage.Exists(x => XmlManager.ins.SpellDatabase.SpellBook[spellIndice].spellName.ToLower().Equals(x.nom)) && counter < spellCount) //Test pour savoir si le sort est déjà dans la liste des sorts connues et si on a pas déjà testé tous les sorts
            {
                spellIndice = rand.Next(spellCount);
                counter++;
            }
            if (counter >= spellCount) // Si tous les sorts sont passés
            {
                Debug.Log("Tu connais déjà tous les sorts");
                return;
            }
            Debug.Log(XmlManager.ins.SpellDatabase.SpellBook[spellIndice].spellName.ToLower());
            player.GetComponent<ImprovedSpellInput>().spellListStorage.Add(new ImprovedSpellInput.SpellStorageEntry(XmlManager.ins.SpellDatabase.SpellBook[spellIndice].spellName.ToLower(), -1, -1));
            player.GetComponent<ImprovedSpellInput>().spellListStorage.Sort(delegate (ImprovedSpellInput.SpellStorageEntry s1, ImprovedSpellInput.SpellStorageEntry s2) {return s1.nom.CompareTo(s2.nom);});
            player.GetComponent<ImprovedSpellInput>().newSpellBlinker.enabled = true;
            string spellList = "Sorts du grimoire :\n";
            foreach (ImprovedSpellInput.SpellStorageEntry sse in player.GetComponent<ImprovedSpellInput>().spellListStorage) //Reconstruction du panneau tab car on ajouté un nouveau sort
            {
                string nouvmark = "";
                string valAtk = "<sprite=2>";
                string valDef = "<sprite=2>";
                if (sse.nouveau)
                {
                    nouvmark = "<sprite=0> ";
                }
                if (sse.valAtk >= 0)
                {
                    valAtk = sse.valAtk.ToString();
                }
                if (sse.valDef >= 0)
                {
                    valDef = sse.valDef.ToString();
                }

                spellList += nouvmark + "<color=" + XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(XmlManager.ins.SpellDatabase.SpellBook.Find(y => y.spellName.Equals(sse.nom)).element)).hexColor + ">" + sse.nom.ToLower() + "</color>     <sprite=3>  " + valAtk + "  |    <sprite=1>  " + valDef + "  \n";
            }
            player.GetComponent<ImprovedSpellInput>().spellsList.text = spellList;
        }
    }
}
 