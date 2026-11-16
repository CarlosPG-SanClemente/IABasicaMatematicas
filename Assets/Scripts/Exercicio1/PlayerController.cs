using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public long speedForce = 20;
    public GameObject ball;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {        
        // Rotación cara a bola (porquiño)
        transform.LookAt(ball.transform.position);
    }

    void FixedUpdate()
    {
        // Movemento do xogador
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 verticalDirection = transform.forward * verticalInput;
        Vector3 horizontalDirection = transform.right * horizontalInput;
        Vector3 vector3Direction = verticalDirection + horizontalDirection;
        Vector3 direction = vector3Direction.normalized;
        rb.MovePosition(rb.position + direction * speedForce * Time.fixedDeltaTime);
    }
}
