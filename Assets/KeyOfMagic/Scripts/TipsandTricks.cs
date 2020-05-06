using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsandTricks : MonoBehaviour {
    private List<string> tips = new List<string> () {
        "Each object has a rarety based on its color : Common<sprite=0> , Rare<sprite=3> , Epic<sprite=1> , et Legendary<sprite=2> .",
        "You can double click to automatically bring yourself to casting range.",
        "You might learn from your foes.",
        "Making this sheet was a good idea. Do not forget to hold Esc to consult it.",
        "Bob was given by the academy. Although he has always been docile, you feel a dormant power in him.",
        "<i>How much do i pay this school to put myself in danger again ?</i> - You",
        "You can't drop an item. They're way too precious anyways.",
        "Exploring might be useful."
    };

    public void couleur() {
        TMP_Text TMP = this.GetComponent<TMP_Text> ();
        // Color32[] newVertexColors;
        System.Random rd = new System.Random ();
        var indice = rd.Next (0, tips.Capacity - 1);
        TMP.text = tips[indice];
        TMP.ForceMeshUpdate(true);
        // if (indice.Equals (0)) {
        //     Debug.Log (TMP.text);
        //     int charCount = TMP.textInfo.characterCount;
        //     Debug.Log (charCount);
        //     int[] offset = new int[] { 55, 61, 71 };
        //     int[] lengths = new int[] { 4, 6, 10 };
        //     Color32[] colors = new Color32[] { new Color32 (19, 114, 113, 255), new Color32 (152, 20, 52, 255), new Color32 (155, 119, 0, 255) };
        //     for (int i = 0; i < 3; i++) {
        //         Color32 c0 = colors[i];
        //         int off = offset[i];
        //         int len = lengths[i];
        //         for (int currentCharacter = 0; currentCharacter < len; currentCharacter++) {
        //             // Get the index of the material used by the current character.
        //             int materialIndex = TMP.textInfo.characterInfo[currentCharacter + off].materialReferenceIndex;

        //             // Get the vertex colors of the mesh used by this text element (character or sprite).
        //             newVertexColors = TMP.textInfo.meshInfo[materialIndex].colors32;
        //             // Get the index of the first vertex used by this text element.
        //             int vertexIndex = TMP.textInfo.characterInfo[currentCharacter + off].vertexIndex;
        //             newVertexColors[vertexIndex + 0] =c0;
        //             newVertexColors[vertexIndex + 1] = c0;
        //             newVertexColors[vertexIndex + 2] = c0;
        //             newVertexColors[vertexIndex + 3] = c0;
        //             // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
        //             TMP.UpdateVertexData (TMP_VertexDataUpdateFlags.Colors32);
        //         }
        //     }
        // }
    }
}