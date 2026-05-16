using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;

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
        // Inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Dirección de la cámara
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Evitar movimiento vertical
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Movimiento relativo a cámara
        Vector3 move =
            cameraForward * vertical +
            cameraRight * horizontal;

        // Magnitud movimiento
        float movementAmount = Mathf.Clamp01(move.magnitude);

        // Detectar correr
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Velocidad actual
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Movimiento personaje
        if (movementAmount > 0.1f)
        {
            controller.Move(
                move.normalized *
                currentSpeed *
                Time.deltaTime
            );
        }

        // Blend Tree
        float targetSpeed = movementAmount;

        if (!isRunning)
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