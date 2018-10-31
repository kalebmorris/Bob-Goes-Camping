using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobFlicker : MonoBehaviour {

    // Use this for initialization
   

    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;


    [SerializeField]
    RuntimeAnimatorController[] characterControllers = new RuntimeAnimatorController[3];

    [SerializeField]
    AudioClip[] breathingSounds = new AudioClip[3];

    private int curr_index = 2;

    private Animator bobAnimator;
    private AudioSource bobAudio;

    public bool flickering = false;

    private void Start()
    {
        bobAnimator = GetComponent<Animator>();
        bobAudio = GetComponent<AudioSource>();
        bobAudio.clip = breathingSounds[curr_index];
        bobAudio.Play();
    }


    void Update()
    {

        if (flickering == true)
        {
            SpriteBlinkingEffect();
        }

    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            flickering = false;
            curr_index--;
            if (curr_index < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }            
            bobAnimator.runtimeAnimatorController = characterControllers[curr_index];
            bobAudio.clip = breathingSounds[curr_index];
            bobAudio.Play();

            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   
            }
        }
    }
}
