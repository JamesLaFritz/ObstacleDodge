#region Header
// LevelGoal.cs
// Author: James LaFritz
// Description: Detects when the player reaches the goal and notifies the GameManager.
#endregion

using DeadlyDodge.Core;
using UnityEngine;

namespace DeadlyDodge.Gameplay
{
    /// <summary>
    /// Trigger volume placed at the end of the level to finish the run when the player reaches the goal.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class LevelGoal : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Player tag used to validate collisions.
        /// </summary>
        [SerializeField] private string _playerTag = "Player";

        /// <summary>
        /// Reference to the GameManager for driving win flow.
        /// </summary>
        [SerializeField] private GameManager _gameManager;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Ensures the collider is configured as a trigger for clean detection.
        /// </summary>
        private void Reset()
        {
            var c = GetComponent<Collider>();
            c.isTrigger = true;
        }

        /// <summary>
        /// Attempts to auto-wire references if they are not assigned in the Inspector.
        /// </summary>
        private void Awake()
        {
            if (_gameManager == null)
            {
                _gameManager = FindAnyObjectByType<GameManager>();
            }
        }

        /// <summary>
        /// Handles the player entering the goal volume.
        /// </summary>
        /// <param name="other">Player collider.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_playerTag)) return;
            _gameManager?.CompleteLevel();
        }

        #endregion
    }
}
