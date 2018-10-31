using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayValue : MonoBehaviour {

    [SerializeField]
    private Text scoreValue;

	void Start () {
        GameObject scoreObject = GameObject.Find("PassScore");
        scoreValue.text = scoreObject.GetComponent<PassScore>().boars.ToString();
    }

    void OnDestroy() {
        Destroy(GameObject.Find("PassScore"));
    }
}
