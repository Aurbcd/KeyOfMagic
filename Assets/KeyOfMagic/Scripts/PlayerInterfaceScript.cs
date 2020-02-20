using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInterfaceScript : MonoBehaviour
{
    public Text text;
    public Image redHealth;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "PV : " + PlayerHealth.playerHealthPoints.ToString();
        scale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        scale.z = PlayerHealth.playerHealthPoints / 100;
        text.text = "PV : " + PlayerHealth.playerHealthPoints.ToString();
        redHealth.GetComponent<RectTransform>().localScale = scale;
    }
}
