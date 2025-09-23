#region Header
// Hazard3D.cs
// Author: James LaFritz
// Description: Generic lethal hazard trigger for MVP. Ends the run when the player enters.
#endregion

using UnityEngine;

namespace DeadlyDodge.Gameplay
{
    /// <summary>
    /// Lethal hazard (requires a 3D Collider set to IsTrigger).
    /// When the Player enters, the run ends (Game Over).
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class Hazard3D : MonoBehaviour
    {
        #region Unity Messages

        /// <summary>
        /// Ensures collider is configured as a trigger on reset.
        /// </summary>
        private void Reset()
        {
            // TODO: GetComponent<Collider>().isTrigger = true;
        }

        /// <summary>
        /// Called when another collider enters this trigger.
        /// </summary>
        /// <param name="other">The collider that entered.</param>
        private void OnTriggerEnter(Collider other)
        {
            // TODO:
            // if (!other.CompareTag("Player")) return;
            // var gm = FindAnyObjectByType<DeadlyDodge.Core.GameManager>();
            // gm?.GameOver();
        }

        #endregion
    }
}