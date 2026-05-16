using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;

    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.W);
        bool isRunning = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift);

        // Animaciones
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);

        // Movimiento
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        if (isWalking)
        {
            Vector3 move = transform.forward * currentSpeed;
            controller.Move(move * Time.deltaTime);
        }
    }
}