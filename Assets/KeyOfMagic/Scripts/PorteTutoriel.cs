﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteTutoriel : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
