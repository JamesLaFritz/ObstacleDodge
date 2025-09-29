#region Header
// GameManager.cs
// Author: James LaFritz
// Description: Wires countdown flow: start run, handle times-up, compute score, show summary.
#endregion

using UnityEngine;

namespace DeadlyDodge.Core
{
    /// <summary>
    /// Orchestrates the MVP flow with countdown loss and time-left scoring.
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        #region Types

        /// <summary>High-level game states.</summary>
        public enum GameState { Title, Controls, Playing, GameOver }

        #endregion

        #region Fields

        /// <summary>Current state.</summary>
        [SerializeField] private GameState _state = GameState.Title;

        /// <summary>Run timer reference.</summary>
        [SerializeField] private RunTimer _timer;

        /// <summary>Score system reference.</summary>
        [SerializeField] private ScoreSystem _score;

        /// <summary>HUD controller for summary.</summary>
        [SerializeField] private UI.HUDController _hud;

        #endregion

        #region Properties

        /// <summary>Current state (read-only).</summary>
        public GameState State => _state;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches refs and subscribes to timer events.
        /// </summary>
        private void Awake()
        {
            if (_timer == null) _timer = FindAnyObjectByType<RunTimer>();
            if (_score == null) _score = FindAnyObjectByType<ScoreSystem>();
            if (_hud == null) _hud = FindAnyObjectByType<UI.HUDController>();
        }

        /// <summary>
        /// Example entry point for a direct Game scene start in MVP.
        /// </summary>
        private void Start()
        {
            // In a multi-scene flow you'd call GoTitle(); for MVP start the run directly:
            StartRun();
        }

        /// <summary>
        /// Register for timer notifications once the object is active.
        /// </summary>
        private void OnEnable()
        {
            if (_timer != null) _timer.TimesUp += FailRun;
        }

        /// <summary>
        /// Unsubscribe from timer notifications when disabled.
        /// </summary>
        private void OnDisable()
        {
            if (_timer != null) _timer.TimesUp -= FailRun;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Starts a new run: resets score and timer, enters Playing state.
        /// </summary>
        public void StartRun()
        {
            _state = GameState.Playing;
            _score?.ResetRun();
            _timer?.ResetTimer();
        }

        /// <summary>
        /// Call this when the player reaches the goal before the timer expires.
        /// Computes score and shows summary (win).
        /// </summary>
        public void CompleteLevel()
        {
            if (_state != GameState.Playing) return;
            _state = GameState.GameOver;

            var timeLeft = _timer != null ? _timer.RemainingSeconds : 0f;
            _score?.ComputeFinalScore(timeLeft);
            _hud?.ShowGameOver();
        }

        /// <summary>
        /// Ends the run due to collision loss or other reasons (if you want).
        /// Not strictly needed since time-out is the primary loss in this design.
        /// </summary>
        public void FailRun()
        {
            if (_state != GameState.Playing) return;
            _state = GameState.GameOver;

            var timeLeft = _timer != null ? _timer.RemainingSeconds : 0f;
            _score?.ComputeFinalScore(timeLeft);
            _hud?.ShowGameOver();
        }

        #endregion
    }
}
