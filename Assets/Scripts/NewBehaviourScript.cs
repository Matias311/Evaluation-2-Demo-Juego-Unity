using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeed = 10f;

    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        // Obtener componentes automáticamente
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Inputs WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Dirección movimiento
        Vector3 move = new Vector3(horizontal, 0f, vertical);

        // Magnitud del movimiento
        float movementAmount = move.magnitude;

        // Detectar correr
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Velocidad actual
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Movimiento
        if (movementAmount > 0.1f)
        {
            // Rotar hacia dirección movimiento
            Quaternion targetRotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // Mover personaje
            controller.Move(
                move.normalized * currentSpeed * Time.deltaTime
            );
        }

        // Blend Tree
        float targetSpeed = move.magnitude;

        if (isRunning)
        {
            targetSpeed *= 1f;
        }
        else
        {
            targetSpeed *= 0.5f;
        }

        animator.SetFloat(
            "Speed",
            targetSpeed,
            0.1f,
            Time.deltaTime
        );
    }
}
