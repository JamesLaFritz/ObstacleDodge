#region Header
// ControlsScreenController.cs
// Author: James LaFritz
// Description: MVP stub for the device-based controls screen (tabs & navigation).
#endregion

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

namespace DeadlyDodge.UI
{
    /// <summary>
    /// Displays controls for keyboard/mouse, gamepad, or mobile.
    /// Auto-selects tab based on last-used device (stubbed here for MVP).
    /// </summary>
    public sealed class ControlsScreenController : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// UIDocument containing the controls layout.
        /// </summary>
        [SerializeField] private UIDocument _uiDocument;

        /// <summary>
        /// Cache of the last detected control scheme id.
        /// </summary>
        private string _lastScheme = "KeyboardMouse";

        #endregion

        #region Unity Messages

        /// <summary>
        /// Locates UI references and sets default tab.
        /// </summary>
        private void OnEnable()
        {
            // TODO:
            // var root = _uiDocument != null ? _uiDocument.rootVisualElement : null;
            // Hook up tab buttons and default selection here.
        }

        /// <summary>
        /// Unsubscribes from any events (if used).
        /// </summary>
        private void OnDisable()
        {
            // TODO: Unhook tab events / input events if wired.
        }

        #endregion

        #region Public API

        /// <summary>
        /// Selects a tab by name (e.g., "KeyboardMouse", "Gamepad", "Touch").
        /// </summary>
        /// <param name="scheme">The scheme id to show.</param>
        public void ShowTab(string scheme)
        {
            // TODO: Toggle UI classes to show the chosen panel and highlight the tab.
        }

        /// <summary>
        /// Continues from the controls screen into the game.
        /// </summary>
        public void StartGame()
        {
            // TODO: Find GameManager and call StartGame().
        }

        #endregion
    }
}
