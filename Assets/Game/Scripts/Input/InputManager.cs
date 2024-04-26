using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public Action<Vector2> OnMoveInput;
    public Action<bool> OnSprintInput;
    public Action OnJumpInput;
    public Action OnClimbInput;
    public Action OnCancelClimb;
    private void Update()
    {
        CheckMovementInput();
        CheckSprintInput();
        CheckJumpInput();
        CheckClimbInput();
        CheckChangePOVInput();
        CheckCrouchInput();
        CheckGlideInput();
        CheckCancelInput();
        CheckPunchInput();
        CheckMainMenuInput();
    }

    private void CheckMovementInput()
    {
        // Mengambil input pada axis horizontal & vertikal
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector2 inputAxis = new Vector2(horizontalAxis, verticalAxis);
        if(OnMoveInput != null)
        {
            OnMoveInput(inputAxis);
        }
    }

    private void CheckSprintInput()
    {
        bool isHoldSprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if(isHoldSprint)
        {
            if(OnSprintInput != null)
            {
                OnSprintInput(true);
            }
        }
        else
        {
            if(OnSprintInput != null)
            {
                OnSprintInput(false);
            }
        }
    }
    private void CheckJumpInput()
    {
        bool isPressJump = Input.GetKeyDown(KeyCode.Space);
        if(isPressJump)
        {
            if(OnJumpInput != null)
            {
                OnJumpInput();
            }
        }
    }
    private void CheckCrouchInput()
    {
        bool isPressCrouch = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);
        if(isPressCrouch)
        {
            Debug.Log("Crouching");
        }
    }
    private void CheckChangePOVInput()
    {
        // Bernilai true jika tombol ditekan
        bool isChangePOV = Input.GetKeyDown(KeyCode.C);
        if(isChangePOV)
        {
            Debug.Log("POV Changed");
        }
    }
    private void CheckClimbInput()
    {
        bool isClimbing = Input.GetKeyDown(KeyCode.Q);
        if(isClimbing)
        {
            OnClimbInput();
        }
    }
    private void CheckGlideInput()
    {
        bool isGliding = Input.GetKeyDown(KeyCode.E);
        if(isGliding)
        {
            Debug.Log("Gliding");
        }
    }
    private void CheckCancelInput()
    {
        bool isCancel = Input.GetKeyDown(KeyCode.X);
        if(isCancel)
        {
            if(OnCancelClimb != null)
            {
                OnCancelClimb();
            }
        }
    }
    private void CheckPunchInput()
    {
        bool isPunching = Input.GetKeyDown(KeyCode.Mouse0);
        if(isPunching)
        {
            Debug.Log("Punching");
        }
    }
    private void CheckMainMenuInput()
    {
        bool isPause = Input.GetKeyDown(KeyCode.Escape);
        if(isPause)
        {
            Debug.Log("Main Menu");
        }
    }
}
