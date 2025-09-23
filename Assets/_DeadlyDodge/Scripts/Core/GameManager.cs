#region Header
// GameManager.cs
// Author: James LaFritz
// Description: High-level state flow for the MVP (Title -> Controls -> Game -> GameOver).
#endregion

using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeadlyDodge.Core
{
    /// <summary>
    /// Coordinates high-level game state transitions and scene routing.
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        #region Types

        /// <summary>
        /// Top-level states for the MVP game flow.
        /// </summary>
        public enum GameState
        {
            /// <summary>Title screen is shown.</summary>
            Title,
            /// <summary>Controls screen is shown.</summary>
            Controls,
            /// <summary>Active gameplay is running.</summary>
            Playing,
            /// <summary>Game over state is shown.</summary>
            GameOver
        }

        #endregion

        #region Fields

        /// <summary>
        /// Current active game state.
        /// </summary>
        [SerializeField] private GameState _state = GameState.Title;

        /// <summary>
        /// Reference to the score system for resetting and summarizing runs.
        /// </summary>
        [SerializeField] private ScoreSystem _scoreSystem;

        /// <summary>
        /// Reference to the HUD controller for showing game over panels, etc.
        /// </summary>
        [SerializeField] private UI.HUDController _hud;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current active game state.
        /// </summary>
        public GameState State => _state;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches references and initializes the title state.
        /// </summary>
        private void Awake()
        {
            // TODO: Cache references if not assigned via Inspector.
            // if (_scoreSystem == null) _scoreSystem = FindAnyObjectByType<ScoreSystem>();
            // if (_hud == null) _hud = FindAnyObjectByType<UI.HUDController>();
        }

        /// <summary>
        /// Called on first frame to ensure we are at the Title flow entry.
        /// </summary>
        private void Start()
        {
            // TODO: Load Title scene or show title overlay.
            // GoTitle();
        }

        #endregion

        #region Public API

        /// <summary>
        /// Enters the Title state and loads the Title scene.
        /// </summary>
        public void GoTitle()
        {
            // TODO: _state = GameState.Title; SceneManager.LoadScene("Title");
        }

        /// <summary>
        /// Enters the Controls state and loads the Controls scene.
        /// </summary>
        public void GoControls()
        {
            // TODO: _state = GameState.Controls; SceneManager.LoadScene("Controls");
        }

        /// <summary>
        /// Starts gameplay and loads the Game scene.
        /// </summary>
        public void StartGame()
        {
            // TODO:
            // _state = GameState.Playing;
            // _scoreSystem?.ResetAll();
            // SceneManager.LoadScene("Game");
        }

        /// <summary>
        /// Ends the current run and shows the game over summary.
        /// </summary>
        public void GameOver()
        {
            // TODO:
            // if (_state != GameState.Playing) return;
            // _state = GameState.GameOver;
            // _scoreSystem?.CommitBest();
            // _hud?.ShowGameOver(_scoreSystem?.CurrentScore ?? 0, _scoreSystem?.BestScore ?? 0);
            // Optionally load a "GameOver" scene instead of showing an overlay.
        }

        #endregion
    }
}
