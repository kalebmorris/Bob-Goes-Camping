using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartup : MonoBehaviour {

    float t;
    [SerializeField]
    private float fadeDuration = 5f;
    [SerializeField]
    private ScreenTransitionImageEffect transition;

    [SerializeField]
    private Text[] HUD = new Text[4];
    [SerializeField]
    private PlayerMovement movement;

    private bool done = false;

    private void Update()
    {
        t += Time.deltaTime / fadeDuration;
        transition.maskValue = Mathf.Lerp(1f, 0f, t);
        if (t > 0.55f && !done) {
            for (int i = 0; i < HUD.Length; i++) {
                HUD[i].enabled = true;
                movement.canMove = true;
            }
            //set these things to active;
        }
    }

    // Use this for initialization
    void Start () {
        t = -0.1f;
    }

}
