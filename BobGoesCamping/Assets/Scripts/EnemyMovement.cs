using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 1.0f;
    private float startTime;
    private GameObject bob;
    //apply a force to it that is bobs force 
    //private Rigidbody2D bob_rb;

    const int UP = 1;
    const int LEFT = 2;
    const int DOWN = 3;
    const int RIGHT = 4;

    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private Collider2D boarCollider;

    private Animator an;

    private bool waited = true;
    // Use this for initialization
    void Start () {
        // = GetComponent<Rigidbody2D>();
        //bob_rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

        bob = GameObject.FindWithTag("Player");
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        //gameObject.SetActive(true);
    }


    void Awake()
    {
        startTime = Time.time;
        StartCoroutine(WaitTillTime());
        StartCoroutine(WaitForTime());
        //an.speed = 0;
    }

    private void Update()
    {
        float t = (Time.time - startTime) / duration;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(duration - duration/5);
        waited = true;
        an.speed = 1;
        boarCollider.enabled = true;
    }

    IEnumerator WaitTillTime()
    {
        yield return new WaitForSeconds(0.2f);
        waited = false;
        an.speed = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (waited)
        {
            transform.position = Vector2.MoveTowards(transform.position, bob.transform.position, movementSpeed * Time.deltaTime);
            //Debug.Log(rb.velocity);

            var dir = bob.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (angle < 0f)
            {
                angle += 360f;
            }


            if (angle > 315f || angle < 45f)
            {

                an.SetInteger("direction", RIGHT);

            }
            else if (angle >= 45f && angle <= 135f)
            {
                an.SetInteger("direction", UP);
            }
            else if (angle > 135f && angle < 225f)
            {
                an.SetInteger("direction", LEFT);
            }
            else if (angle >= 225f && angle <= 315f)
            {
                an.SetInteger("direction", DOWN);
            }
        }
    }

    public float GetSpeed() {
        return movementSpeed;
    }

    public void SetSpeed(float speed) {
        movementSpeed = speed;
    }
}
