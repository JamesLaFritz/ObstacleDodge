#region Header
// SpinnerPhysicsRotator .cs
// Author: James LaFritz
// Description: Kinematic Rigidbody spinner that rotates in FixedUpdate via MoveRotation.
#endregion

using UnityEngine;

namespace DeadlyDodge.Hazards
{
    /// <summary>
    /// Rotates a hazard using a kinematic Rigidbody so physics sees continuous motion
    /// (reliable contacts and consistent tangential push along the whole length).
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class SpinnerPhysicsRotator : MonoBehaviour
    {
        #region Fields

        /// <summary>Local-space angular velocity in degrees per second.</summary>
        [SerializeField] private Vector3 _angularSpeedDegPerSec = new Vector3(0f, 180f, 0f);

        /// <summary>Optional amplitude to modulate speed (0..1) for variety.</summary>
        [SerializeField, Range(0f, 1f)] private float _speedScale = 1f;

        /// <summary>
        /// 
        /// </summary>
        private Rigidbody _rb;

        #endregion

        #region Unity Messages

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            // Ensure correct kinematic setup for moving colliders.
            _rb.isKinematic = true;
            _rb.useGravity = false;
            _rb.interpolation = RigidbodyInterpolation.Interpolate; 
        }

        /// <summary>
        /// 
        /// </summary>
        private void FixedUpdate()
        {
            // Convert degrees/sec to delta rotation for this physics step.
            var dt = Time.fixedDeltaTime;
            var deg = _angularSpeedDegPerSec * _speedScale * dt;
            var dq = Quaternion.Euler(deg);

            // MoveRotation gives PhysX a swept rotation for better contacts.
            _rb.MoveRotation(_rb.rotation * dq);
        }

        #endregion
    }
}