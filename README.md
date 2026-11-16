# UD04 - IA Básica Matemáticas

## Explicación da escena implementada

Texto normal con **negriña** e *cursiva*.
Elementos na escena
- Balón (porquiño): é un rigibody e usa o motor de físicas. Está envolto por un collider tipo capsula para que sexa mais doado darlle.
- Xogador, un dos prefabs tipo cápsula que había no proxecto, tamén é un rigidbody e **pódese mover de esqueda-dereita e adiante-atras**. A **rotación é automática para facilitar o movemento** e sempre mira ao porquiño
- Porteiro. Se ben é un rigidbody está marcado como isKinematic para que ignore golpes. Movese sen usar o motor de fisicas traladando o transform. Móvese de esquerda a dereita da porteria e uso 2 boxcolliders a modo de extremos que actúan como triggers que cambian a dirección do porteiro.
- Porteria. Elemento fixo. Só ten colliders.


[Ligazón](https://exemplo.com)

**Movemento do xogador**
```csharp
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


```

**Movemento do porteiro**
``` csharp
using UnityEngine;

public class GoalKeeperController : MonoBehaviour
{
    Vector3 direction = Vector3.right;
    private float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("GKPoint"))
        {
            direction *= -1;
        }
    }
}

```