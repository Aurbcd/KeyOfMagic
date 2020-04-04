using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulte : MonoBehaviour
{
    public float difficulte;

    void Start(){
        difficulte = 1.5f;
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
