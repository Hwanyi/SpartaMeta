using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;
    public bool isDead = false;

    bool isFlap = false;

    public bool godMode = false;

    FlappyManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FlappyManager.instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        if(gameManager.state == FlappyManager.State.Start)
        {
            _rigidbody.velocity = Vector3.zero;
            transform.position = Vector3.zero;
            return;
        }

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if(isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();

    }
}
