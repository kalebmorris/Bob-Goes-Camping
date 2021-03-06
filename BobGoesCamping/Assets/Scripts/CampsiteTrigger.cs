﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampsiteTrigger : MonoBehaviour {

    private WoodManager wm;

    private void Start()
    {
        wm = GameObject.FindWithTag("WoodManager").GetComponent<WoodManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            wm.StoreCollected();
        }
    }
}
