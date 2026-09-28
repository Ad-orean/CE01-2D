using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] Color collisionColor = Color.red;
    [SerializeField] ParticleSystem collisionEffect;
    [SerializeField] SpriteRenderer carRender;

    SpriteRenderer sr;
    bool isKey;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0f);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter");
        if (other.CompareTag("Test"))
        {
            isKey = true;
            carRender.color = Color.yellow;
            collisionEffect.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit");
        if (other.CompareTag("Test"))
        {
            isKey = false;
            carRender.color = Color.white;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected " + collision.gameObject.name);

        sr.color = collisionColor;

        if (collision.collider.CompareTag("Test"))
        {
            Debug.Log("Collision with Test");
            return;
        }

        Destroy(collision.gameObject);
    }
}
