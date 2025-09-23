#region Header
// HUDController.cs
// Author: James LaFritz
// Description: Updates score and timer UI, and shows a simple Game Over panel.
#endregion

using UnityEngine;
using TMPro;

namespace DeadlyDodge.UI
{
    /// <summary>
    /// MVP HUD binding for score/time UI and a simple game-over summary.
    /// </summary>
    public sealed class HUDController : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Text element displaying the current score.
        /// </summary>
        [SerializeField] private TMP_Text _scoreText;

        /// <summary>
        /// Text element displaying the elapsed time.
        /// </summary>
        [SerializeField] private TMP_Text _timerText;

        /// <summary>
        /// Root panel for the game-over UI.
        /// </summary>
        [SerializeField] private GameObject _gameOverPanel;

        /// <summary>
        /// Reference to the score system used for reading values.
        /// </summary>
        [SerializeField] private DeadlyDodge.Core.ScoreSystem _scoreSystem;

        /// <summary>
        /// Local timer display (optional; can read directly from ScoreSystem if desired).
        /// </summary>
        private float _elapsedForDisplay = 0f;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches references if needed.
        /// </summary>
        private void Awake()
        {
            // TODO:
            // if (_scoreSystem == null) _scoreSystem = FindAnyObjectByType<DeadlyDodge.Core.ScoreSystem>();
        }

        /// <summary>
        /// Updates the timer and score readouts each frame.
        /// </summary>
        private void Update()
        {
            // TODO:
            // _elapsedForDisplay += Time.deltaTime;
            // if (_timerText) _timerText.text = $"Time: {_elapsedForDisplay:F1}";
            // if (_scoreText && _scoreSystem != null) _scoreText.text = $"Score: {_scoreSystem.CurrentScore}";
        }

        #endregion

        #region Public API

        /// <summary>
        /// Shows the game-over panel and writes summary text.
        /// </summary>
        /// <param name="score">Final run score.</param>
        /// <param name="bestScore">Session-best score.</param>
        public void ShowGameOver(int score, int bestScore)
        {
            // TODO:
            // if (_gameOverPanel == null) return;
            // _gameOverPanel.SetActive(true);
            // var text = _gameOverPanel.GetComponentInChildren<TMP_Text>();
            // if (text != null) text.text = $"Score: {score}\nBest: {bestScore}";
        }

        #endregion
    }
}
