#region Header
// PlayerAnimationController.cs
// Author: James LaFritz
// Description: Bridges gameplay movement input to animator parameters for Dart.
#endregion

using UnityEngine;

namespace DeadlyDodge.Gameplay
{
    /// <summary>
    /// Applies locomotion input values to animator parameters (InputX/InputY).
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerAnimationController : MonoBehaviour
    {
        /// <summary>
        /// Animator hash for the horizontal input parameter.
        /// </summary>
        private static readonly int InputXHash = Animator.StringToHash("InputX");

        /// <summary>
        /// Animator hash for the vertical input parameter.
        /// </summary>
        private static readonly int InputYHash = Animator.StringToHash("InputY");

        /// <summary>
        /// Cached animator reference used to set movement parameters.
        /// </summary>
        private Animator _animator;

        /// <summary>
        /// Grab the animator component when the object awakens.
        /// </summary>
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Updates animator parameters using the supplied movement vector.
        /// </summary>
        /// <param name="value">Movement vector (x = horizontal, y = vertical).</param>
        public void OnMove(Vector2 value)
        {
            _animator.SetFloat(InputXHash, value.x);
            _animator.SetFloat(InputYHash, value.y);
        }
    }
}
