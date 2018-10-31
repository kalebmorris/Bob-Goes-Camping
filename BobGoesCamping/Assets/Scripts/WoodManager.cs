using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WoodManager : MonoBehaviour
{

    private FireManager fm;
    [SerializeField]
    private Transform wood = null;
    [SerializeField]
    private float spawnTime = 10.0f;
    [SerializeField]
    private int numWoodToLevel = 5;
    [SerializeField]
    private Text woodText;
    private float timer;
    private System.Random random;
    private int numCollected = 0;
    private int numInFire = 0;


    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
        random = new System.Random();
        fm = GameObject.FindWithTag("FireManager").GetComponent<FireManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0.0f;
            SpawnRandom();
        }
    }

    private void SpawnRandom()
    {
        Transform spawn = Instantiate(wood);
        float noise = (float)random.NextDouble();
        bool neg = random.NextDouble() > .5d ? true : false;
        noise = neg ? -noise : noise;
        switch (random.Next(1, 15))
        {
            case 1:
                spawn.Translate(new Vector3(-20, 0 + noise));
                break;
            case 2:
                spawn.Translate(new Vector3(-13, 5 + noise));
                break;
            case 3:
                spawn.Translate(new Vector3(-13, -3 + noise));
                break;
            case 4:
                spawn.Translate(new Vector3(-6, -7 + noise));
                break;
            case 5:
                spawn.Translate(new Vector3(-6, 9 + noise));
                break;
            case 6:
                spawn.Translate(new Vector3(-6, 0 + noise));
                break;
            case 7:
                spawn.Translate(new Vector3(20, 0 + noise));
                break;
            case 8:
                spawn.Translate(new Vector3(13, 5 + noise));
                break;
            case 9:
                spawn.Translate(new Vector3(13, -3 + noise));
                break;
            case 10:
                spawn.Translate(new Vector3(6, -7 + noise));
                break;
            case 11:
                spawn.Translate(new Vector3(6, 9 + noise));
                break;
            case 12:
                spawn.Translate(new Vector3(6, 0 + noise));
                break;
            case 13:
                spawn.Translate(new Vector3(0, 5 + noise));
                break;
            case 14:
                spawn.Translate(new Vector3(0, -3 + noise));
                break;
            default:
                break;
        }
    }

    public void IncrementCollected() {
        numCollected++;
        woodText.text = (Int32.Parse(woodText.text) + 1).ToString();
    }

    public void StoreCollected() {
        numInFire += numCollected;
        numCollected = 0;
        woodText.text = "0";
        if (numInFire >= numWoodToLevel) {
            int numLevels = numInFire / numWoodToLevel;
            numInFire = numInFire % numWoodToLevel;
            fm.UpgradeFire(numLevels);
        }
    }
}
