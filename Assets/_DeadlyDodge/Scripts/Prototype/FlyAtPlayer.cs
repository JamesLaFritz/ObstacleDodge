#region Header
// MoveTowardsTarget.cs
// Author: [Your Name]
// Description: Moves a projectile toward a target position (player's position at Start).
#endregion

using UnityEngine;

/// <summary>
/// Moves this object toward a target position (typically the player's position at Start).
/// </summary>
public class FlayAtPlayer : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Movement speed (units per second).
    /// </summary>
    [SerializeField] private float _speed = 10f;

    /// <summary>
    /// The player's Transform. Used to capture the initial target position.
    /// </summary>
    [SerializeField] private Transform _playersTransform;

    /// <summary>
    /// Target position captured at Start (course stores a plain Vector3).
    /// </summary>
    private Vector3 _targetPosition;

    #endregion

    #region Unity Messages
    
    /// <summary>
    /// Course disables the object in some steps.)
    /// </summary>
    private void Awake()
    {
        // TODO:
        // Disable the game object
    }

    /// <summary>
    /// Captures the player's current position as the target and configures gravity.
    /// </summary>
    private void Start()
    {
        // TODO:
        // _targetPosition = _playersTransform.position;
    }

    /// <summary>
    /// Moves toward the target each frame and destroys the object when it arrives.
    /// </summary>
    private void Update()
    {
        // TODO:
        // 1) Move toward _targetPosition (Vector3.MoveTowards).
        // 3) Destroy when the target is reached.
        // Hint: The course uses direct MoveTowards in Update then destroys when positions match.
    }

    #endregion

    #region Methods

    /// <summary>
    /// Destroys the object when it reaches or is close enough to the target.
    /// </summary>
    /// <returns>True if the object was destroyed or flagged for destruction.</returns>
    private void DestroyWhenReached()
    {
        // TODO:
        // Check if the object is close enough to the target and destroy it.
    }

    #endregion
}
