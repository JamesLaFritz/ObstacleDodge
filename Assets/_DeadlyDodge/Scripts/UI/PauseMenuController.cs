#region Header
// PauseMenuController.cs
// Author: James LaFritz
// Description: Handles pause toggling and menu navigation during gameplay.
#endregion

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
        private bool _isPaused = false;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Initializes the pause menu hidden.
        /// </summary>
        private void Start()
        {
            // TODO:
            // if (_pausePanel != null) _pausePanel.SetActive(false);
            // _isPaused = false;
            // Time.timeScale = 1f;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Toggles pause on/off.
        /// </summary>
        public void TogglePause()
        {
            // TODO:
            // _isPaused = !_isPaused;
            // Time.timeScale = _isPaused ? 0f : 1f;
            // if (_pausePanel != null) _pausePanel.SetActive(_isPaused);
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