#region Header
// HUDController.cs
// Author: James LaFritz
// Description: Displays remaining time and final summary (time-left scoring plus no-hit bonus).
#endregion

using UnityEngine;
using TMPro;
using DeadlyDodge.Core;

namespace DeadlyDodge.UI
{
    /// <summary>
    /// Binds the countdown readout to text and shows a summary at game over.
    /// </summary>
    public sealed class HUDController : MonoBehaviour
    {
        #region Fields

        /// <summary>Text element for the current remaining time.</summary>
        [SerializeField] private TMP_Text _timerText;

        /// <summary>Text element for the current hit count (optional).</summary>
        [SerializeField] private TMP_Text _hitsText;

        /// <summary>Root panel for Game Over summary.</summary>
        [SerializeField] private GameObject _gameOverPanel;

        /// <summary>Summary text shown at Game Over (score, time left, hits).</summary>
        [SerializeField] private TMP_Text _summaryText;

        /// <summary>RunTimer reference.</summary>
        [SerializeField] private RunTimer _timer;

        /// <summary>ScoreSystem reference.</summary>
        [SerializeField] private ScoreSystem _score;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches references if not assigned.
        /// </summary>
        private void Awake()
        {
            if (_timer == null) _timer = FindAnyObjectByType<RunTimer>();
            if (_score == null) _score = FindAnyObjectByType<ScoreSystem>();
            if (_gameOverPanel != null) _gameOverPanel.SetActive(false);
        }

        /// <summary>
        /// Updates HUD readouts each frame.
        /// </summary>
        private void Update()
        {
            if (_timerText != null && _timer != null)
                _timerText.text = $"Time: {_timer.RemainingSeconds:F1}";

            if (_hitsText != null && _score != null)
                _hitsText.text = $"Hits: {_score.HitCount}";
        }

        #endregion

        #region Public API

        /// <summary>
        /// Shows a Game Over summary panel. Call from GameManager after ComputeFinalScore.
        /// </summary>
        public void ShowGameOver()
        {
            if (_gameOverPanel == null || _summaryText == null || _timer == null || _score == null)
            {
                if (_gameOverPanel != null) _gameOverPanel.SetActive(true);
                return;
            }

            _gameOverPanel.SetActive(true);
            _summaryText.text =
                $"Time Left: {_timer.RemainingSeconds:F1}\n" +
                $"Hits: {_score.HitCount}\n" +
                $"Score: {_score.FinalScore}\n" +
                $"Best: {_score.BestScore}";
        }

        #endregion
    }
}
