#region Header
// PlayerController3D.cs
// Author: James LaFritz
// Description: 3D planar movement for Dart using CharacterController and the New Input System (callbacks).
#endregion

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DeadlyDodge.Gameplay
{
    /// <summary>
    /// Moves the player on the XZ plane using a CharacterController.
    /// </summary>
    [RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(Animator))]
    public sealed class PlayerController3D : MonoBehaviour
    {
        private static readonly int MoveXHash = Animator.StringToHash("InputX");
        private static readonly int MoveYHash = Animator.StringToHash("InputY");

        #region Fields

        /// <summary>
        /// Camera transform used to compute camera-relative movement (optional).
        /// </summary>
        [SerializeField] private Transform _cameraTransform;

        /// <summary>
        /// Movement speed in meters per second.
        /// </summary>
        [SerializeField] private float _moveSpeed = 6f;

        /// <summary>
        /// Gravity in m/s^2 applied to vertical velocity when not grounded.
        /// </summary>
        [SerializeField] private float _gravity = -25f;

        /// <summary>
        /// Downward stick force to keep the controller grounded on slopes.
        /// </summary>
        [SerializeField] private float _groundStickForce = -2f;

        /// <summary>
        /// Cached input vector (X = right, Y = forward).
        /// </summary>
        private Vector2 _moveInput = Vector2.zero;

        /// <summary>
        /// Current world-space velocity (y used for gravity).
        /// </summary>
        private Vector3 _velocity = Vector3.zero;

        /// <summary>
        /// Cached CharacterController reference.
        /// </summary>
        private CharacterController _cc;
        
        private Animator _animator;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches the CharacterController and camera transform references.
        /// </summary>
        private void Awake()
        {
            _cc = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            // TODO:
            // if (_cameraTransform == null && Camera.main != null) _cameraTransform = Camera.main.transform;
        }

        /// <summary>
        /// Updates movement and gravity each frame.
        /// </summary>
        private void Update()
        {
            // TODO:
            // 1) Compute camera-relative forward/right (XZ only).
            // 6) Optionally rotate to face movement direction.
            
            // Build the desired direction from _moveInput.
            var desiredHorizontal = _moveInput.x * transform.right;
            var desiredVertical = _moveInput.y * transform.forward;
            
            // Apply _moveSpeed to horizontal.
            var desiredMovement = (desiredHorizontal + desiredVertical).normalized * _moveSpeed;
            
            // Apply gravity to _velocity.y.
            _velocity.y += _gravity * Time.deltaTime;
            
            // Move via _cc.Move().
            _cc.Move((desiredMovement + _velocity) * Time.deltaTime);
        }

        #endregion

        #region Input

        /// <summary>
        /// Input System callback for the "Move" action (Vector2).
        /// </summary>
        /// <param name="ctx">Input callback context.</param>
        public void OnMove(InputAction.CallbackContext ctx)
        {
            _moveInput = ctx.ReadValue<Vector2>();
            _animator.SetFloat(MoveXHash, _moveInput.x);
            _animator.SetFloat(MoveYHash, _moveInput.y);
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
}
