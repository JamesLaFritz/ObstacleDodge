#region Header
// ObjectHit.cs
// Author: [Your Name]
// Description: Tracks when hazards are hit by the player cube.
// Notes: Requires MeshRenderer to optionally change the visual on hit (not covered in the course).
#endregion

using UnityEngine;

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
        // TODO: Cache the MeshRenderer.
        // _meshRenderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// Called when this collider first comes into contact with another collider.
    /// </summary>
    /// <param name="other">The collision information of the other object.</param>
    private void OnCollisionEnter(Collision other)
    {
        // TODO:
        // 1) Only react when the Player hits this object.
        // if (!other.gameObject.CompareTag("Player")) return;
        //
        // 2) Swap material to _hitMaterial, if assigned.
        //
        // 3) Mark this object as "Hit" so the scorer can ignore repeated hits.
        //
        // 4) Debug.Log a message with this object's name.
        // Debug.Log($"Dart has hit {name}", this);
    }

    #endregion
}
