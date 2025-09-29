#region Header
// RunTimer.cs
// Author: James LaFritz
// Description: Central countdown timer for the current run. Supports time penalties and times-up event.
// ToDo: Implement in Unity
#endregion

using System;
using UnityEngine;

namespace DeadlyDodge.Core
{
    /// <summary>
    /// Owns the countdown timer for a run. Ticks down every frame, supports penalties,
    /// and raises an event when time reaches zero.
    /// </summary>
    public sealed class RunTimer : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Total time (seconds) granted to complete the level.
        /// </summary>
        [SerializeField, Min(0f)] private float _levelTimeSeconds = 90f;

        /// <summary>
        /// Optional floor clamp so negatives never display.
        /// </summary>
        [SerializeField, Min(0f)] private float _minDisplayClamp;

        /// <summary>
        /// Current remaining time (seconds).
        /// </summary>
        private float _remainingSeconds;

        /// <summary>
        /// True, once the timer has reached zero and fired TimesUp.
        /// </summary>
        private bool _isExpired;

        /// <summary>
        /// 
        /// </summary>
        public event Action<float> PenaltyApplied;

        #endregion

        #region Properties

        /// <summary>Current remaining time (seconds).</summary>
        public float RemainingSeconds => Mathf.Max(_remainingSeconds, _minDisplayClamp);

        /// <summary>True if the timer has reached zero.</summary>
        public bool IsExpired => _isExpired;

        #endregion

        #region Events

        /// <summary>
        /// Raised once when the timer reaches zero.
        /// </summary>
        public event Action TimesUp;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Initializes the timer from level configuration.
        /// </summary>
        private void Start()
        {
            ResetTimer();
        }

        /// <summary>
        /// Decrements the timer and fires TimesUp once at zero.
        /// </summary>
        private void Update()
        {
            if (_isExpired) return;

            _remainingSeconds -= Time.deltaTime;
            if (!(_remainingSeconds <= 0f)) return;
            _remainingSeconds = 0f;
            _isExpired = true;
            TimesUp?.Invoke();
        }

        #endregion

        #region Public API

        /// <summary>
        /// Resets the timer to the configured level time.
        /// </summary>
        public void ResetTimer()
        {
            _remainingSeconds = Mathf.Max(0f, _levelTimeSeconds);
            _isExpired = false;
        }

        /// <summary>
        /// Applies a time penalty in seconds (e.g., on obstacle hit).
        /// </summary>
        /// <param name="seconds">Amount to subtract (seconds).</param>
        public void ApplyPenalty(float seconds)
        {
            if (_isExpired) return;
            var s = Mathf.Max(0f, seconds);
            _remainingSeconds -= s;
            PenaltyApplied?.Invoke(s);
            if (!(_remainingSeconds <= 0f)) return;
            _remainingSeconds = 0f;
            _isExpired = true;
            TimesUp?.Invoke();
        }

        #endregion
    }
}
