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

    [SerializeField] private AnimationCurve JumpFall;
    [SerializeField] private float JumpMultiplier;
    [SerializeField] private KeyCode JumpKey;
    private bool JumpActive;

    private void Awake()
    {
        charController = GetComponent<CharacterController>(); //Takes the CharacterController from the Players Inspector
    }

    private void Update()
    {
        PlayerMove();
        InputToJump();
    }

    private void PlayerMove()
    {
        float HorizontalInput = Input.GetAxis(horizontalInputName) * MovementSpeed;
        float VerticalInput = Input.GetAxis(verticalInputName) * MovementSpeed;

        Vector3 MoveForward = transform.forward * VerticalInput;
        Vector3 MoveRight = transform.right * HorizontalInput;

        charController.SimpleMove(MoveForward + MoveRight);
    }

    private void InputToJump()
    {
        if(Input.GetKeyDown(JumpKey) && !JumpActive)
        {
            JumpActive = true;
            StartCoroutine(JumpingAction());
        }
    }
    
    private IEnumerator JumpingAction()
    {
        float AirTime = 0.0f;
        do
        {
            float JumpForce = JumpFall.Evaluate(AirTime);
            charController.Move(Vector3.up * JumpForce * JumpMultiplier * Time.deltaTime);
            AirTime += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
        JumpActive = false;

    }
}