#region Header
// TriggerProjectile.cs
// Author: James LaFritz
// Description: Triggers multiple projectiles when the player enters a volume.
// Notes: Array-based approach vs. 5 explicit references (as seen in the course).
#endregion

using UnityEngine;

namespace Prototype
{
    /// <summary>
    /// Triggers one or more projectiles to fly toward the player's position when the player
    /// enters this trigger volume.
    /// </summary>
    public class TriggerProjectile : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// Projectiles that will be launched toward the player's position.
        /// (Array approach is not used in the course; the course uses separate fields.)
        /// </summary>
        [SerializeField] private FlyAtPlayer[] _projectiles;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Called when another collider enters this trigger volume.
        /// </summary>
        /// <param name="other">The collider that entered.</param>
        private void OnTriggerEnter(Collider other)
        {
            // TODO:
            // 1) Only react to the Player.
            if (!other.CompareTag("Player")) return;
            
            // 2) Activate/launch all projectiles toward the player's current position.
            if (_projectiles == null || _projectiles.Length == 0) return;
            foreach (var projectile in _projectiles)
            {
                if (projectile == null) continue;
                projectile.gameObject.SetActive(true);
                projectile.Target(other.transform.position);
            }
            //
            // 3) Destroy/disable this trigger after firing.
            Destroy(gameObject);
        }

        #endregion
    }
}