using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimator : MonoBehaviour {

    public float moveDistance;
    public float endX;
    public float begX;

    // Update is called once per frame
    void Update () {
        if (System.Math.Abs(transform.position.x - endX) < 2) {
            transform.Translate(-1 * endX + begX, 0, 0);
        }

        transform.Translate(moveDistance, 0, 0);
	}
}
