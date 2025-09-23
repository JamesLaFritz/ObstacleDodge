#region Header
// Spinner.cs
// Author: [Your Name]
// Description: Rotates a hazard object over time.
// Notes: [Range] attributes are shown to demonstrate Inspector sliders.
#endregion

using UnityEngine;

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
    [Range(0f, 1f)]
    [SerializeField] private float _xRotationAmount = 0f;

    /// <summary>
    /// Normalized rotation contribution on the Y axis (0..1).
    /// </summary>
    [Range(0f, 1f)]
    [SerializeField] private float _yRotationAmount = 1f;

    /// <summary>
    /// Normalized rotation contribution on the Z axis (0..1).
    /// </summary>
    [Range(0f, 1f)]
    [SerializeField] private float _zRotationAmount = 0f;

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
        // TODO:
        // Set the rotation axis and speed based on the axis values.
        // rotate the object
    }

    #endregion
}