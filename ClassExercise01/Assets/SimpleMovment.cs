using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    void Start()
    {
        Debug.Log("Movement script started");
    }

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
