#region Header
// ObjectHit.cs
// Author: James LaFritz
// Description: Tracks when hazards are hit by the player cube.
// Notes: Requires MeshRenderer to optionally change the visual on hit (not covered in the course).
#endregion

using UnityEngine;

namespace Prototype
{

    /// <summary>
    /// Handles collision logic for hazards. Marks hazards as "Hit" when collided with the player.
    /// Optionally swaps material for visual feedback (MeshRenderer required).
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class ObjectHit : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Material to apply after this object is hit. Optional; used for visual feedback.
        /// (Null checks and guard clauses are not covered in the beginner course; explained in comments.)
        /// </summary>
        [SerializeField] private Material _hitMaterial;

        /// <summary>
        /// Cached MeshRenderer used to swap materials on hit.
        /// </summary>
        private MeshRenderer _meshRenderer;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches the MeshRenderer reference on Awake.
        /// </summary>
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        /// <summary>
        /// Called when this collider first comes into contact with another collider.
        /// </summary>
        /// <param name="other">The collision information of the other object.</param>
        private void OnCollisionEnter(Collision other)
        {
            // 1) Only react when the Player hits this object.
            if (!other.gameObject.CompareTag("Player")) return;

            // 2) (Optional) Swap material to _hitMaterial, if assigned.
            if (_hitMaterial != null)
            {
                _meshRenderer.material = _hitMaterial;
            }

            // 3) Mark this object as "Hit" so the scorer can ignore repeated hits.
            gameObject.tag = "Hit";
            //
            // 4) (Optional) Debug.Log a message with this object's name.
            //Debug.Log($"Dart has hit {name}", this);
        }

        #endregion
    }
}