#region Header
// Dropper.cs
// Author: James LaFritz
// Description: Makes a hazard cube fall after a delay using Rigidbody.
// Notes: Uses MeshRenderer to optionally hide the object until it drops.
#endregion

using UnityEngine;

namespace Prototype
{
    /// <summary>
    /// Causes a cube to drop after a set delay using gravity. Optionally hidden until drop.
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
    public class Dropper : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Time (in seconds) to wait before enabling gravity.
        /// </summary>
        [SerializeField] private float _timeToWait = 2f;

        /// <summary>
        /// Rigidbody used to enable gravity when the timer expires.
        /// </summary>
        private Rigidbody _rigidbody;

        /// <summary>
        /// MeshRenderer used to hide/show the object until drop.
        /// </summary>
        private MeshRenderer _meshRenderer;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches references to required components.
        /// </summary>
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        /// <summary>
        /// Initializes the drop timer and disables gravity/visibility at start.
        /// </summary>
        private void Start()
        {
            // Start the timer and disable gravity/visibility.
            _rigidbody.useGravity = false;
            _meshRenderer.enabled = false; // optional: hidden until drop
        }

        /// <summary>
        /// Counts down and enables gravity (and visibility) when the timer elapses.
        /// </summary>
        private void Update()
        {
            // Enable gravity and mesh render when time has lasted long enough.
            if (Time.time < _timeToWait) return;
            
            _meshRenderer.enabled = true;
            _rigidbody.useGravity = true;
            Debug.Log("Look out below!");
        }

        #endregion
    }
}