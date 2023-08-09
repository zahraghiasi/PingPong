using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{

    public float speed;
    public float offset = 0.2f;
    public bool isHuman = true;

    public KeyCode down;
    public KeyCode up;

    private Rigidbody rb;

    private Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHuman){
            humanControl();
        } else {
            aiControl();
        }
    }

    private void aiControl(){
        if(ball.position.z < transform.position.z + offset) {
            rb.velocity = Vector3.back * speed;
        }

        else if(ball.position.z > transform.position.z - offset) {
            rb.velocity = Vector3.forward * speed;
        }

        else {
            rb.velocity = Vector3.zero;
        }

    }

    private void humanControl() {
        bool pressedDown = Input.GetKey(this.down);
        bool pressedUp = Input.GetKey(this.up);

        if (pressedDown) {
            rb.velocity = Vector3.back * speed;
        }

        if (pressedUp) {
            rb.velocity = Vector3.forward * speed;
        }

        if (!pressedDown && !pressedUp){
            rb.velocity = Vector3.zero;
        }
    }
}
