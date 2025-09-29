#region Header
// PlayerRigidbodyController.cs
// Author: James LaFritz
// Description: Rigidbody-driven planar movement for Dart on the XZ plane.
// Notes: Reads movement input and moves via Rigidbody in FixedUpdate.
#endregion

using UnityEngine;

/// <summary>
/// Moves the player (Dart) on the XZ plane using a non-kinematic <see cref="Rigidbody"/>.
/// Designed for a top-down/maze feel with snappy, capped movement.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public sealed class PlayerRigidbodyController : MonoBehaviour
{
    #region Fields


    /// <summary>
    /// Movement speed in meters per second.
    /// </summary>
    [SerializeField] private float _moveSpeed = 6f;

    /// <summary>
    /// Cached input vector (X = right, Y = forward).
    /// </summary>
    private Vector2 _moveInput = Vector2.zero;

    /// <summary>
    /// Tracks vertical velocity applied through custom gravity.
    /// </summary>
    private float _verticalVelocity;

    /// <summary>
    /// Cached reference to the player's Rigidbody.
    /// </summary>
    private Rigidbody _rigidbody;

    #endregion

    #region Unity Messages

    /// <summary>
    /// Caches the Rigidbody and initializes physical properties.
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    /// <summary>
    /// Applies movement in the physics loop for smooth, stable motion.
    /// </summary>
    private void FixedUpdate()
    {
        // Desired horizontal velocity from input
        Vector3 desired = new Vector3(_moveInput.x, 0f, _moveInput.y) * _moveSpeed;

        // Preserve current vertical velocity (gravity/jumps if you add them later)
        Vector3 v = _rigidbody.linearVelocity;
        v.x = desired.x;
        v.z = desired.z;

        _rigidbody.linearVelocity = v; // Let solver/friction resolve contact against moving spinner
    }

    #endregion

    #region Input (Optional Callbacks)

    /// <summary>
    /// Input System callback for the "Move" action (Vector2).
    /// This is used if a PlayerInput component is present (Invoke Unity Events).
    /// </summary>
    /// <param name="value">The Value to set the Move Input to.</param>
    public void OnMove(Vector2 value)
    {
        _moveInput = value;
    }

    #endregion
}
