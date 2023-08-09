using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 direction;
    private bool stopped = true;

    public float speed;
    public float directionMinimum = 0.5f;
    public GameObject sparksVFX;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(this.stopped)
            return;
        
        this.rb.MovePosition(this.rb.position + direction * Time.fixedDeltaTime * speed);
    }

    private void OnTriggerEnter(Collider collider) {
        bool hit = false;

        if (collider.CompareTag("Wall")) {
            direction.z = -direction.z;
            hit = true;
        }

        if(collider.CompareTag("Racket")) {
            Vector3 newDirection = (transform.position - collider.transform.position).normalized;
            newDirection.x = Mathf.Max(this.directionMinimum, Mathf.Abs(newDirection.x)) * Mathf.Sign(newDirection.x);
            newDirection.z = Mathf.Max(this.directionMinimum, Mathf.Abs(newDirection.z)) * Mathf.Sign(newDirection.z);
            direction = newDirection;
            hit = true;
        }

        if(hit) {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void chooseDirection() {
        float signX = Mathf.Sign(Random.Range(-1f,1f));
        float signZ = Mathf.Sign(Random.Range(-1f,1f));
        this.direction = new Vector3(signX * 0.5f, 0, signZ * 0.5f);
    }

    public void Go() {
        chooseDirection();
        this.stopped = false;
    }

    public void Stop() {
        this.stopped = true;
    }
}
