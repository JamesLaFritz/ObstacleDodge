#region Header
// PauseMenuController.cs
// Author: James LaFritz
// Description: Handles pause toggling and menu navigation during gameplay.
#endregion

using System;
using DeadlyDodge.Core;
using UnityEngine;

namespace DeadlyDodge.UI
{
    /// <summary>
    /// Simple pause controller for the MVP (toggle pause, open controls, quit to title).
    /// </summary>
    public sealed class PauseMenuController : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Root panel for the pause menu UI.
        /// </summary>
        [SerializeField] private GameObject _pausePanel;

        /// <summary>
        /// Tracks whether the game is currently paused.
        /// </summary>
        private bool _isPaused;
        
        /// <summary>
        /// 
        /// </summary>
        private GameManager _gameManager;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches references.
        /// </summary>       
        private void Awake()
        {
            _gameManager = FindFirstObjectByType<GameManager>();
        }

        /// <summary>
        /// Initializes the pause menu hidden.
        /// </summary>
        private void Start()
        {
            // Hide the pause panel.
            if (_pausePanel != null) _pausePanel.SetActive(false);
            // Set the initial state to not paused.
            _isPaused = false;
            // Set the time scale to 1 (unpaused).
            Time.timeScale = 1;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Toggles pause on/off.
        /// </summary>
        public void TogglePause()
        {
            // Toggle the pause state.
            _isPaused = !_isPaused;
            // Update the time scale.
            Time.timeScale = _isPaused ? 0 : 1;
            // Hide or Show based on the state
            if (_pausePanel == null) return;
            _pausePanel.SetActive(_isPaused);
        }

        /// <summary>
        /// Shows the Controls screen from pause (optional).
        /// </summary>
        public void OpenControls()
        {
            // TODO: Find GameManager and route to Controls (or open overlay).
        }

        /// <summary>
        /// Quits the run and returns to the Title screen.
        /// </summary>
        public void QuitToTitle()
        {
            // TODO: Find GameManager and call GoTitle().
        }

        #endregion
    }
}