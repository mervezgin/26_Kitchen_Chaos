using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    private float moveSpeed = 7f;
    private float rotateSpeed = 10f;
    private bool isWalking;
    private float playerRadius = 0.7f;
    private float playerHeight = 2f;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);
        if (!canMove)
        {
            //cannot move towards movedir

            //attempt only x movement 
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

            if (canMove)
            {
                //can move only on the x 
                moveDirection = moveDirectionX;
            }
            else
            {
                //cannot move only on the x 

                //attempt only z movement
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);

                if (canMove)
                {
                    //can move only on the z
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    //cannot move any directions
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        isWalking = moveDirection != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}
