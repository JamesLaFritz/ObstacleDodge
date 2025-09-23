#region Header
// ScoreSystem.cs
// Author: James LaFritz
// Description: Tracks survival time and computes MVP score.
#endregion

using UnityEngine;

namespace DeadlyDodge.Core
{
    /// <summary>
    /// Computes score from survival time and exposes the best score.
    /// </summary>
    public sealed class ScoreSystem : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Accumulated elapsed time for the current run.
        /// </summary>
        private float _elapsed = 0f;

        /// <summary>
        /// Current run's integer score.
        /// </summary>
        private int _currentScore = 0;

        /// <summary>
        /// Highest score achieved in this session.
        /// </summary>
        private int _bestScore = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current run's score.
        /// </summary>
        public int CurrentScore => _currentScore;

        /// <summary>
        /// Gets the highest score achieved this session.
        /// </summary>
        public int BestScore => _bestScore;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Updates elapsed time and recomputes the score each frame.
        /// </summary>
        private void Update()
        {
            // TODO:
            // _elapsed += Time.deltaTime;
            // _currentScore = Mathf.RoundToInt(_elapsed * 10f); // Simple MVP formula.
        }

        #endregion

        #region Public API

        /// <summary>
        /// Resets score and elapsed time for a new run.
        /// </summary>
        public void ResetAll()
        {
            // TODO:
            // _elapsed = 0f;
            // _currentScore = 0;
        }

        /// <summary>
        /// Commits the current score to the best score if it is higher.
        /// </summary>
        public void CommitBest()
        {
            // TODO:
            // if (_currentScore > _bestScore) _bestScore = _currentScore;
        }

        #endregion
    }
}
