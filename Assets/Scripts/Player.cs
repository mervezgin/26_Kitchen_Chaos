using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float rotateSpeed = 10f;
    private void Start()
    {

    }
    private void Update()
    {
        Vector2 inputVector = new Vector2(0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1f;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
}
