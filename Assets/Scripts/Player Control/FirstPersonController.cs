using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Player Settings")]
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;
    public Transform playerCamera;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private float xRotation = 0f;

    private void Start()
    {
        // Ініціалізація CharacterController
        controller = GetComponent<CharacterController>();

        // Заморожуємо курсор на екрані для контролю миші
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Контролюємо рух миші для повороту гравця і камери
        HandleMouseLook();

        // Контролюємо рух гравця
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Обмежуємо рух камери вгору і вниз
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Рух камери вгору-вниз (по осі X)
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Поворот гравця по осі Y
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Отримуємо введення для пересування (клавіатура WASD або стрілки)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * playerSpeed * Time.deltaTime);

        // Стрибки
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Застосовуємо гравітацію
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

