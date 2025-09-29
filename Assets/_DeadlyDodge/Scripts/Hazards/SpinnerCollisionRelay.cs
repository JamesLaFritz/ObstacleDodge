#region Header
// SpinnerCollisionRelay.cs
// Author: James LaFritz
// Description: Forwards parent Rigidbody collision events to the correct child Hazard3D
#endregion

using System.Collections.Generic;
using UnityEngine;
using DeadlyDodge.Gameplay;

/// <summary>
/// Relays rigidbody collision events on a rotating spinner to child Hazard3D components.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public sealed class SpinnerCollisionRelay : MonoBehaviour
{
    /// <summary>
    /// Optional: log which arm was hit for debugging.
    /// </summary>
    [SerializeField] private bool _debug;

    /// <summary>
    /// Cache: from any child Collider to the Hazard3D that owns that arm.
    /// </summary>
    private readonly Dictionary<Collider, Hazard3D> _colliderToHazard = new();

    /// <summary>
    /// Builds the collider → hazard lookup used when relaying collisions.
    /// </summary>
    private void Awake()
    {
        // Build a lookup so relaying is O(1) at runtime.
        // We allow multiple colliders under the same arm; they all map to that arm's Hazard3D.
        var hazards = GetComponentsInChildren<Hazard3D>(includeInactive: true);
        foreach (var hz in hazards)
        {
            var cols = hz.GetComponentsInChildren<Collider>(includeInactive: true);
            foreach (var col in cols)
            {
                // Skip the parent's collider if it exists (ideally, the parent has no collider).
                if (col.attachedRigidbody == GetComponent<Rigidbody>() && col.gameObject == gameObject)
                    continue;

                _colliderToHazard[col] = hz;
            }
        }
    }

    /// <summary>
    /// Routes incoming collisions from the parent rigidbody to the relevant hazard arms.
    /// </summary>
    /// <param name="collision">Physics collision data provided by Unity.</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Gather unique child arms touched this frame (capsule/contact can report multiple).
        var uniqueHazards = _scratchHazards;
        uniqueHazards.Clear();

        foreach (var contact in collision.contacts)
        {
            var thisCol = contact.thisCollider;       // the collider on THIS compound body
            if (thisCol && _colliderToHazard.TryGetValue(thisCol, out var hz))
                uniqueHazards.Add(hz);
        }

        foreach (var hz in uniqueHazards)
        {
            if (_debug) Debug.Log($"Spinner hit arm: {hz.name}", hz);
            hz.OnCollisionEnter(collision);
        }
    }

    /// <summary>
    /// Reuse a set to avoid allocs each event
    /// </summary>
    private readonly HashSet<Hazard3D> _scratchHazards = new();
}
