#region Header
// MoveTowardsTarget.cs
// Author: James LaFritz
// Description: Moves a projectile toward a target position (player's position at Start).
// Notes: The course version does not use Rigidbody; this template includes optional Rigidbody support.
#endregion

using UnityEngine;

namespace Prototype
{
    /// <summary>
    /// Moves this object toward a target position (typically the player's position at Start).
    /// </summary>
    [RequireComponent(typeof(Rigidbody))] // Not used in the course version; kept here to show an alternative path.
    public class FlyAtPlayer : MonoBehaviour
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
        /// Distance threshold for considering the target "reached".
        /// Not used in the course; provided for convenience.
        /// </summary>
        [SerializeField] private float _distanceToTargetThreshold = 0.5f;

        /// <summary>
        /// Whether to enable gravity on the Rigidbody while moving.
        /// Not used in the course; provided for experimentation.
        /// </summary>
        [SerializeField] private bool _useGravity;

        /// <summary>
        /// Current distance to the target position (debug/optional logic).
        /// </summary>
        private float _distanceToTarget = float.MaxValue;

        /// <summary>
        /// Target position captured at Start (course stores a plain Vector3).
        /// </summary>
        private Vector3? _targetPosition;

        /// <summary>
        /// Optional Rigidbody reference (the course version omits this).
        /// </summary>
        private Rigidbody _rigidbody;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Course disables the object in some steps.
        /// </summary>
        private void Awake()
        {
            // Disable the game object
            _rigidbody = GetComponent<Rigidbody>();
            gameObject.SetActive(false); // only if following that part of the course
        }

        /// <summary>
        /// Captures the player's current position as the target and configures gravity.
        /// </summary>
        private void Start()
        {
            if (_playersTransform != null) _targetPosition = _playersTransform.position;
            _rigidbody.useGravity = false;
        }

        /// <summary>
        /// Moves toward the target each frame and destroys the object when it arrives.
        /// </summary>
        private void Update()
        {
            if (MoveTowards()) return;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets a new target position at runtime and toggles gravity if desired.
        /// </summary>
        /// <param name="targetPosition">World-space position to move toward.</param>
        public void Target(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            _rigidbody.useGravity = _useGravity;
        }

        /// <summary>
        /// Moves toward the target position if valid. Returns true if processing should stop.
        /// </summary>
        /// <returns>True if we cannot/should not move further (no target or already reached).</returns>
        private bool MoveTowards()
        {
            if (!_targetPosition.HasValue) return true;
            if (_distanceToTarget < _distanceToTargetThreshold) return true;
            
            Vector3 next = Vector3.MoveTowards(transform.position, _targetPosition.Value, _speed * Time.deltaTime);
            transform.position = next;
            
            _distanceToTarget = Vector3.Distance(transform.position, _targetPosition.Value);
            return DestroyWhenReached();
        }

        /// <summary>
        /// Destroys the object when it reaches or is close enough to the target.
        /// </summary>
        /// <returns>True if the object was destroyed or flagged for destruction.</returns>
        private bool DestroyWhenReached()
        {
            if (!_targetPosition.HasValue) return false;
            
            if (_distanceToTarget < _distanceToTargetThreshold)
            {
                if (_useGravity) Destroy(gameObject, 3f); // optional linger if using gravity
                else Destroy(gameObject);
                return true;
            }
            
            return false;
        }

        #endregion
    }
}