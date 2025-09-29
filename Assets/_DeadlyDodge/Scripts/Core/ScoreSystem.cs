#region Header
// ScoreSystem.cs
// Author: James LaFritz
// Description: Tracks hits and computes final score from remaining time + no-hit bonus.
#endregion

using System;
using UnityEngine;

namespace DeadlyDodge.Core
{
    /// <summary>
    /// MVP scoring: base points equal to remaining time (ceil),
    /// with an optional bonus if the run had zero obstacle hits.
    /// </summary>
    public sealed class ScoreSystem : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Bonus points awarded if the player completes the level without any hits.
        /// </summary>
        [SerializeField, Min(0)] private int _noHitBonusPoints = 250;

        /// <summary>
        /// How many times the player has hit an obstacle this run.
        /// </summary>
        private int _hitCount;

        /// <summary>
        /// Cached final score for summary screens.
        /// </summary>
        private int _finalScore;

        /// <summary>
        /// Highest score achieved in this session (simple in-memory).
        /// </summary>
        private int _bestScore;
        
        /// <summary>
        /// Fired whenever the hit count increments; passes the updated value.
        /// </summary>
        public event Action<int> HitCountChanged;

        #endregion

        #region Properties

        /// <summary>Total hits this run.</summary>
        public int HitCount => _hitCount;

        /// <summary>Final computed score for this run.</summary>
        public int FinalScore => _finalScore;

        /// <summary>Best score across runs this session.</summary>
        public int BestScore => _bestScore;

        #endregion

        #region Public API

        /// <summary>
        /// Clears run stats (hits, final score). Call when a new run starts.
        /// </summary>
        public void ResetRun()
        {
            _hitCount = 0;
            _finalScore = 0;
        }

        /// <summary>
        /// Registers a player obstacle hit.
        /// </summary>
        public void RegisterHit()
        {
            _hitCount++;
            HitCountChanged?.Invoke(_hitCount);
            Debug.Log($"Hit count: {_hitCount}");
        }

        /// <summary>
        /// Computes the final score based on remaining time and bonuses.
        /// </summary>
        /// <param name="remainingTimeSeconds">Time left when finishing or expiring.</param>
        public void ComputeFinalScore(float remainingTimeSeconds)
        {
            var baseScore = Mathf.CeilToInt(Mathf.Max(0f, remainingTimeSeconds));
            var bonus = (_hitCount == 0) ? _noHitBonusPoints : 0;
            _finalScore = baseScore + bonus;

            if (_finalScore > _bestScore)
                _bestScore = _finalScore;
        }

        #endregion
    }
    
}
