using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(moveX * moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
