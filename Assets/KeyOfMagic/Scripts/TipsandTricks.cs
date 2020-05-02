using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsandTricks : MonoBehaviour
{
    public List<string> tips = new List<string>() {
            "Chaque rareté d'objet est liée à une couleur : Commun, Rare, Epique et Légendaire.",
            "Vous pouvez double-cliquer sur un ennemi pour automatiquement vous mettre à distance d'attaque.",
            "Vous pouvez apprendre de vos ennemis.",
            "Vous avez vraiment bien fait de faire cette fiche. N'oubliez pas d'appuyer sur Echap pour la consulter",
            "Bob est un cadeau de l'académie. Bien qu'il a toujours été docile, vous sentez une puissance dormante en lui.",
            "<i>Combien je paye cette école pour y risquer ma vie déjà ?</i> - Vous",
            "Vous ne pouvez pas vous deséquiper d'un objet. Ils sont de toutes façons bien trop précieux."
    };

    void Start()
    {
        var TMP = this.GetComponent<TextMeshProUGUI>();
        Color32[] newVertexColors;
        System.Random rd = new System.Random();
        var indice = rd.Next(0,tips.Capacity -1);
        TMP.text = tips[indice];
        if (indice.Equals(0))
        {
            TMP.ForceMeshUpdate();
            int charCount = TMP.textInfo.characterCount;
            int[] offset = new int[]{55, 61, 71};
            int[] lengths = new int[]{4, 6, 10 };
            Color32[] colors = new Color32[]{new Color32(19, 114, 113, 255), new Color32(152, 20, 52, 255), new Color32(155, 119, 0, 255)};
            for (int i = 0; i < 3; i++)
            {
                Color32 c0 = colors[i];
                int off = offset[i];
                int len = lengths[i];
                for (int currentCharacter = 0; currentCharacter < len; currentCharacter++)
                {
                    // Get the index of the material used by the current character.
                    int materialIndex = TMP.textInfo.characterInfo[currentCharacter + off].materialReferenceIndex;

                    // Get the vertex colors of the mesh used by this text element (character or sprite).
                    newVertexColors = TMP.textInfo.meshInfo[materialIndex].colors32;
                    // Get the index of the first vertex used by this text element.
                    int vertexIndex = TMP.textInfo.characterInfo[currentCharacter + off].vertexIndex;
                    newVertexColors[vertexIndex + 0] = c0;
                    newVertexColors[vertexIndex + 1] = c0;
                    newVertexColors[vertexIndex + 2] = c0;
                    newVertexColors[vertexIndex + 3] = c0;
                }
                // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
                TMP.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }
        }
    }
}
