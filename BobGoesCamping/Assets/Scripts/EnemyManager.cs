using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private Text score;
    [SerializeField]
    private Transform enemyPrefab;
    [SerializeField]
    private float spawnTime = 4f;
    private int numKilled = 0;
    //private System.Random random;

    [SerializeField]
    AudioClip squealSound;
    AudioSource source;

    bool spawning = true;

    private void Awake()
    {
        source = GetComponent<AudioSource>(); 
    }


    void Start () {
        StartCoroutine(Spawning());
	}

    IEnumerator Spawning() {
        while (spawning) {
            yield return new WaitForSeconds(spawnTime);
            int choice = UnityEngine.Random.Range((int) 1, (int) 9);
            Transform boar = null; 
           
            //float noise = (float)random.NextDouble();
            //bool neg = random.NextDouble() > .5d ? true : false;
            //noise = neg ? -noise : noise;
            switch (choice) {
                case 1: 
                    //Instantiate(enemyPrefab, new Vector3(-17, 6, 0), transform.rotation);
                    boar = Instantiate(enemyPrefab, new Vector3(-17, 6, 0), transform.rotation);

                    break;
                case 2:
                    boar = Instantiate(enemyPrefab, new Vector3(0.7f, 10, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(0.7f, 10, 0), transform.rotation);
                    break;
                case 3:
                    boar = Instantiate(enemyPrefab, new Vector3(17, 5, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(17, 5, 0), transform.rotation);
                    break;
                case 4:
                    boar = Instantiate(enemyPrefab, new Vector3(21.5f, -1.3f, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(21.5f, -1.3f, 0), transform.rotation);
                    break;
                case 5:
                    boar = Instantiate(enemyPrefab, new Vector3(16.5f, -7.8f, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(16.5f, -7.8f, 0), transform.rotation);
                    break;
                case 6:
                    boar = Instantiate(enemyPrefab, new Vector3(0, -12, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(0, -12, 0), transform.rotation);
                    break;
                case 7:
                    boar = Instantiate(enemyPrefab, new Vector3(-16.8f, -7.9f, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(-16.8f, -7.9f, 0), transform.rotation);
                    break;
                case 8:
                    boar = Instantiate(enemyPrefab, new Vector3(-21.2f, -1.1f, 0), transform.rotation);
                    //Instantiate(enemyPrefab, new Vector3(-21.2f, -1.1f, 0), transform.rotation);
                    break;

            }
            EnemyMovement movement = boar.GetComponent<EnemyMovement>();
            float movementNoise = UnityEngine.Random.Range(0f, 1.5f);
            //Debug.Log(movementNoise);
            movement.SetSpeed(movement.GetSpeed() + movementNoise);

        }
    }


    void Update() {

    }

    public void IncrementKilled() {
        numKilled++;
        score.text = numKilled.ToString();
        source.PlayOneShot(squealSound, .5f);
    }
}
