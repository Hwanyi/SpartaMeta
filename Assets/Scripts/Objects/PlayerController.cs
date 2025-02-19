using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementDirection;
    private Rigidbody2D _rigidbody;

    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical).normalized;
        _camera.transform.position = gameObject.transform.position + Vector3.back;

    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = movementDirection * 5.0f;
       
    }
}
