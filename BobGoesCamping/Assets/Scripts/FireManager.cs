using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] fires = new GameObject[4];
    [SerializeField]
    private float countdown = 10.0f;
    private float soFar;
    private int currFire = 1;

    private AudioSource fireAudio;

	// Use this for initialization
	void Start () {
        fireAudio = GetComponent<AudioSource>();
        fireAudio.volume = .25f;
	}
	
	// Update is called once per frame
	void Update () {
        soFar += Time.deltaTime;
        if (soFar > countdown) {
            soFar = 0.0f;
            if (currFire > 0) {
                fires[currFire].SetActive(false);
                currFire--;
                fireAudio.volume -= .25f;
                fires[currFire].SetActive(true);
                if (currFire == 0) {
                    fireAudio.Pause();
                    GameObject[] boars = GameObject.FindGameObjectsWithTag("Boar");
                    for (int i = 0; i < boars.Length; i++)
                    {
                        EnemyMovement movement = boars[i].GetComponent<EnemyMovement>();
                        movement.SetSpeed(movement.GetSpeed() * 2 + .1f * i);
                    }
                }
            }
        }
	}

    public void UpgradeFire(int numLevels) {
        if (currFire == 0) return;
        fireAudio.volume += .25f;
        fires[currFire].SetActive(false);
        if (currFire + numLevels > 3) {
            currFire = 3;
        } else {
            currFire += numLevels;
        }
        fires[currFire].SetActive(true);
    }
}
