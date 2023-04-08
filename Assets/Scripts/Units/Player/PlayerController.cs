
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FireBallController fireBallController; 
    
    private void OnMove(InputValue inputValue)
    {
        playerMovement.Move(inputValue.Get<Vector2>());
    }

    private void OnJump()
    {
        playerMovement.Jump();
    }

    private void OnFireBall()
    {
        fireBallController.CanFire();
    }
}
