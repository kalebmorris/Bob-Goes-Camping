using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarOnTrigger : MonoBehaviour {

    [SerializeField]
    private BobFlicker flicker;
    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        flicker = player.GetComponent<BobFlicker>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !flicker.flickering)
        {
            flicker.flickering = true;
        }
    }
}
