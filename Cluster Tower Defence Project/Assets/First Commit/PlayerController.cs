using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //SerialzeField shows private data in the inspector
    [SerializeField] private string horizontalInputName; 
    [SerializeField] private string verticalInputName;
    [SerializeField] float MovementSpeed;

    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>(); //Takes the CharacterController from the Players Inspector
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float HorizontalInput = Input.GetAxis(horizontalInputName) * MovementSpeed;
        float VerticalInput = Input.GetAxis(verticalInputName) * MovementSpeed;

        Vector3 MoveForward = transform.forward * VerticalInput;
        Vector3 MoveRight = transform.right * HorizontalInput;

        charController.SimpleMove(MoveForward + MoveRight);
    }
}