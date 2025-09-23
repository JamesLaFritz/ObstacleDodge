#region Header
// Scorer.cs
// Author: [Your Name]
// Description: Tracks and increments score when hazards are hit.
#endregion

using UnityEngine;

/// <summary>
/// Keeps track of the number of hazards the player has collided with.
/// Intended for simple Console feedback in the prototype.
/// </summary>
public class Scorer : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Counter for the number of unique collisions.
    /// </summary>
    private int _hitCount = 0;

    #endregion

    #region Unity Messages

    /// <summary>
    /// Called when this collider first comes into contact with another collider.
    /// </summary>
    /// <param name="other">The collision information of the other object.</param>
    private void OnCollisionEnter(Collision other)
    {
        // TODO:
        // 1) Ignore if the thing we collided with is already marked as "Hit".
        //
        // 2) Also ignore if we collided with the Player itself (depends on your setup).
        // if (other.gameObject.CompareTag("Player")) return;
        //
        // 3) Increment the hit count and log to the Console.
    }

    #endregion
}