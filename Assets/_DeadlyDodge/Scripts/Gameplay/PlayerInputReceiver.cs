#region Header
// PlayerInputReceiver.cs
// Author: James LaFritz
// Description: Reads Input System callbacks and forwards values to a PlayerRigidbodyController.
#endregion

using DeadlyDodge.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Receives Input System callbacks and forwards them to a target controller.
/// Useful if you want to keep all input code out of the controller.
/// </summary>
[RequireComponent(typeof(PlayerInput), typeof(PlayerRigidbodyController))]
public sealed class PlayerInputReceiver : MonoBehaviour
{
    #region Fields
    
    /// <summary>
    /// Latest movement vector read from the Input System.
    /// </summary>
    private Vector2 _moveInput;

    /// <summary>
    /// The controller that will receive movement values.
    /// </summary>
    private PlayerRigidbodyController _playerController;

    /// <summary>
    /// True when a PlayerRigidbodyController was cached successfully.
    /// </summary>
    private bool _hasPlayerController;
    
    /// <summary>
    /// Optional animator bridge for relaying movement values.
    /// </summary>
    private PlayerAnimationController _animator;
    
    /// <summary>
    /// True when an animator bridge component was found.
    /// </summary>
    private bool _hasAnimator;

    #endregion

    #region Unity Messages

    /// <summary>
    /// Validates references on load.
    /// </summary>
    private void Awake()
    {
        _hasPlayerController = TryGetComponent(out _playerController);
        _hasAnimator = TryGetComponent(out _animator);
        
    }

    #endregion

    #region Input

    /// <summary>
    /// Callback for "Move" (Vector2) from a PlayerInput component.
    /// </summary>
    /// <param name="ctx">Input callback context.</param>
    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        if(_hasPlayerController) _playerController.OnMove(_moveInput);
        if(_hasAnimator) _animator.OnMove(_moveInput);
    }

    /// <summary>
    /// Optional input callback for a "Dodge" action (if enabled in MVP).
    /// </summary>
    /// <param name="ctx">Input callback context.</param>
    public void OnDodge(InputAction.CallbackContext ctx)
    {
        // TODO: Reserved for optional feature; keep empty for MVP.
    }

    #endregion
}
