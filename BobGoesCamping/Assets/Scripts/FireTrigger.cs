using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour {

    [SerializeField]
    private BobFlicker flicker;
    [SerializeField]
    private Transform meat = null;
    [SerializeField]
    private float burnDelay = .02f;
    private EnemyManager em;
    private PassScore ps;

	// Use this for initialization
	void Start () {
        em = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        ps = GameObject.Find("PassScore").GetComponent<PassScore>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Boar") {
            StartCoroutine(BurnBoar(other.gameObject));
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !flicker.flickering)
        {
            flicker.flickering = true;
            //StartCoroutine(reenableTrigger(other));
            //ontriggerexit might make this work
        }
    }


    IEnumerator BurnBoar(GameObject boar) {
        yield return new WaitForSeconds(burnDelay);
        Transform meatSpawn = Instantiate(meat);
        if (boar != null) {
            meatSpawn.position = boar.transform.position + (new Vector3(0.26f, 0.36f));
        }

        Destroy(boar);
        em.IncrementKilled();
        ps.IncrementBoars();
    }
}
