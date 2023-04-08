
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private SpellController spellController; 
    
    private void OnMove(InputValue inputValue)
    {
        playerMovement.Move(inputValue.Get<Vector2>());
    }

    private void OnJump()
    {
        playerMovement.Jump();
    }

    private void OnFire()
    {
        spellController.CanFire();
    }
}
