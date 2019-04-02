using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Rigidbody2D rigidbody;

    float radius;
    float padWidth;
    float padHit = 0.0f;
    float xPos, yPos;

    public float moveSpeed = 6.0f;
    public float minRand = 0.0f, maxRand = 1.0f;
    public float minForce = -30, maxForce = 30;

    Vector3 movement;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();

        float r = Random.Range(minRand, maxRand);
        if (r > 0.5f) {
            movement = new Vector3 (maxForce-5, maxForce, 0);
        } else {
            movement = new Vector3 (minForce+5, maxForce, 0);
        }
        startPos = rigidbody.position;
        // StartCoroutine("InitForce");
        radius = transform.localScale.x / 2;
        padWidth = rigidbody.GetComponent<Renderer>().bounds.size.x;
        rigidbody.AddForce(movement * moveSpeed);
    }

    // IEnumerator InitForce() {
        //yield return new WaitForSeconds(4);
        // rigidbody.AddForce(movement * moveSpeed);
    // }

    void NewBall() {
        float r = Random.Range(minRand, maxRand);
        if (r <= 0.25f) {
            movement = new Vector3 (maxForce-5, maxForce, 0);
        } else if (r >= 0.75f) {
            movement = new Vector3 (minForce+5, maxForce, 0);
        } else if (r < 0.5f) {
            movement = new Vector3 (maxForce-5, minForce, 0);
        } else {
            movement = new Vector3 (minForce+5, minForce, 0);
        }
        rigidbody.position = startPos;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(movement * moveSpeed);
    }

    void Update() {
        rigidbody.freezeRotation = true;
        xPos = rigidbody.position.x;
        yPos = rigidbody.position.y;
        Debug.Log("x: " + xPos + "  y: " + yPos);
        if (xPos < 0 || xPos > 200 || yPos < -1 || yPos > 8 || Input.GetKeyDown("space")) {
            NewBall();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "PadTop") {
            rigidbody.AddForce(new Vector3 (padHit, moveSpeed*movement.y*-2, 0));
        }
        if (other.gameObject.tag == "PadBot") {
            rigidbody.AddForce(new Vector3 (padHit, moveSpeed*movement.y*2, 0));
        }
        if (other.gameObject.tag == "WallLeft") {
            rigidbody.AddForce(new Vector3 (moveSpeed*movement.x*2, 0, 0));
        }
        if (other.gameObject.tag == "WallRight") {
            rigidbody.AddForce(new Vector3 (moveSpeed*movement.x*-2, 0, 0));
        }
    }

    // void OnTriggerEnter2D(Collider2D other) {
    //     if (other.GetComponent<Collider>().GetType() == typeof(BoxCollider2D)) {
    //         if (other.gameObject.tag == "PadTop") {
    //             rigidbody.AddForce(new Vector3 (padHit, moveSpeed*movement.y*-2, 0));
    //         }
    //         if (other.gameObject.tag == "PadBot") {
    //             rigidbody.AddForce(new Vector3 (padHit, moveSpeed*movement.y*2, 0));
    //         }
    //         if (other.gameObject.tag == "WallLeft") {
    //             rigidbody.AddForce(new Vector3 (moveSpeed*movement.x*2, 0, 0));
    //         }
    //         if (other.gameObject.tag == "WallRight") {
    //             rigidbody.AddForce(new Vector3 (moveSpeed*movement.x*-2, 0, 0));
    //         }
    //     } else if (other.GetComponent<Collider>().GetType() == typeof(CircleCollider2D)) {
    //         if (other.gameObject.tag == "BotCornerRight") {
    //             rigidbody.AddForce(new Vector3(0, 0, 0));
    //         }
    //         if (other.gameObject.tag == "BotCornerLeft") {
    //             rigidbody.AddForce(new Vector3(0, 0, 0));
    //         }
    //         if (other.gameObject.tag == "TopCornerRight") {
    //             rigidbody.AddForce(new Vector3(0, 0, 0));
    //         }
    //         if (other.gameObject.tag == "TopCornerLeft") {
    //             rigidbody.AddForce(new Vector3(0, 0, 0));
    //         }
    //     }
    // }
}
