using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadControllerBot : MonoBehaviour {

    public Rigidbody2D rigidbody;

    float horizontal;

    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start() {

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        rigidbody.freezeRotation = true;
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate() {

        rigidbody.velocity = new Vector2(horizontal * moveSpeed, 0);
    }

    // void OnTriggerEnter2D(Collider2D other) {
    //     // If a missile hits this object
    //     if (other.transform.tag == "Missile")
    //     {
    //         Debug.Log("HIT!");
    //
    //         // Spawn an explosion at each point of contact
    //         foreach (ContactPoint2D missileHit in other.contacts)
    //         {
    //             Vector2 hitPoint = missileHit.point;
    //
    //         }
    //     }
    // }
}
