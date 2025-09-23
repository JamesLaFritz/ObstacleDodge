#region Header
// Spinner.cs
// Author: James LaFritz
// Description: Rotates a hazard object over time.
// Notes: [Range] attributes are shown to demonstrate Inspector sliders.
#endregion

using UnityEngine;

namespace Prototype
{
    /// <summary>
    /// Continuously rotates an object in the scene to act as a hazard.
    /// Uses per-axis rotation amounts and a global speed multiplier.
    /// </summary>
    public class Spinner : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Normalized rotation contribution on the X axis (0..1).
        /// Demonstrates [Range] usage to create an Inspector slider.
        /// </summary>
        [Range(0f, 1f)] [SerializeField] private float _xRotationAmount;

        /// <summary>
        /// Normalized rotation contribution on the Y axis (0..1).
        /// </summary>
        [Range(0f, 1f)] [SerializeField] private float _yRotationAmount = 1f;

        /// <summary>
        /// Normalized rotation contribution on the Z axis (0..1).
        /// </summary>
        [Range(0f, 1f)] [SerializeField] private float _zRotationAmount;

        /// <summary>
        /// Rotation speed in degrees per second (scaled by the axis amounts).
        /// </summary>
        [SerializeField] private float _rotationSpeed = 100f;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Applies rotation every frame.
        /// </summary>
        private void Update()
        {
            // Set the rotation axis and speed based on the axis values.
            Vector3 axis = new Vector3(_xRotationAmount, _yRotationAmount, _zRotationAmount);
            // rotate the object
            transform.Rotate(axis * (_rotationSpeed * Time.deltaTime));
        }

        #endregion
    }
}