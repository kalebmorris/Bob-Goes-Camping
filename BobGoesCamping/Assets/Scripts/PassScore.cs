using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassScore : MonoBehaviour {

    public int boars = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public void IncrementBoars() {
        boars = boars + 1;
    }

}
