using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _jumpForce;

    private bool _grounded;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
        if (_grounded) Jump();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * (_movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * (_movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right* (_movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * (_movementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            _grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _grounded = true;
        }
    }
}
