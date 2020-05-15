using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SpellFromScroll : MonoBehaviour
{
    private bool ouvert;
    public static AudioClip notifBlinker;
    public static AudioClip parchemin;
    public AudioMixerGroup soundEffectAutres;
    public AudioMixerGroup soundEffectNotif;
    void Start()
    {
        ouvert = false;
        notifBlinker = Resources.Load<AudioClip>("NotifBlinker");
        parchemin = Resources.Load<AudioClip>("Parchemin");

        var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == transform.gameObject)
                continue;

            transform.position = hit.point;
            break;
        }
    }

    void OnMouseDown()
    {
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 9)
        {
            if (!ouvert)
            {
                int spellCount = XmlManager.ins.SpellDatabase.SpellBook.Count;
                int spellIndice = 0;
                int counter = 0; //Pour savoir si on a vu tous les sorts
                System.Random rand = new System.Random();
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
                while (ImprovedSpellInput.spellListStorage.Exists(x => XmlManager.ins.SpellDatabase.SpellBook[spellIndice].spellName.ToLower().Equals(x.nom)) && counter < spellCount) //Test pour savoir si le sort est déjà dans la liste des sorts connues et si on a pas déjà testé tous les sorts
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
                ImprovedSpellInput.spellListStorage.Add(new ImprovedSpellInput.SpellStorageEntry(XmlManager.ins.SpellDatabase.SpellBook[spellIndice].spellName.ToLower(), -1, -1));
                ImprovedSpellInput.spellListStorage.Sort(delegate (ImprovedSpellInput.SpellStorageEntry s1, ImprovedSpellInput.SpellStorageEntry s2) { return s1.nom.CompareTo(s2.nom); });
                player.GetComponent<ImprovedSpellInput>().newSpellBlinker.enabled = true;
                string spellList = "Sorts du grimoire :\n";
                foreach (ImprovedSpellInput.SpellStorageEntry sse in ImprovedSpellInput.spellListStorage) //Reconstruction du panneau tab car on ajouté un nouveau sort
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
                    ouvert = true;
                    player.GetComponent<ImprovedSpellInput>().SonNotifBlinker();
                    GetComponent<AudioSource>().outputAudioMixerGroup = soundEffectAutres;
                    GetComponent<AudioSource>().PlayOneShot(parchemin, 0.4f);
                    gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Read", true);
                }
                player.GetComponent<ImprovedSpellInput>().spellsList.text = spellList;
            }
        }
    }
}
 