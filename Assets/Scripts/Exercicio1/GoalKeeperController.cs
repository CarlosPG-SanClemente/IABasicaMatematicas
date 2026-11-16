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
