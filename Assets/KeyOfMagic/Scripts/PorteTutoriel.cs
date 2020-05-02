using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteTutoriel : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject.Find("Canvas").GetComponent<LevelLoader>().ChangeScene();
    }
}
