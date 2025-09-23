#region Header
// Mover.cs
// Author: [Your Name]
// Description: Moves the player cube in the prototype using either old or new input.
// Notes: Supports both legacy Input.GetAxis() and new Input System polling (manual).
#endregion

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles movement for the player cube in the beginner prototype.
/// Choose either legacy input (Input.GetAxis) or new Input System polling (manual).
/// </summary>
public class Mover : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Movement speed multiplier (units per second).
    /// </summary>
    [SerializeField] private float _moveSpeed = 5f;

    /// <summary>
    /// Cached movement vector built from input each frame.
    /// </summary>
    private Vector3 _moveInput = Vector3.zero;

    #endregion

    #region Unity Messages

    /// <summary>
    /// Called when the object is first enabled. Prints quick instructions.
    /// </summary>
    private void Start()
    {
        PrintInstructions();
    }

    /// <summary>
    /// Called every frame; reads input and moves the player cube.
    /// </summary>
    private void Update()
    {
        MovePlayer();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Prints welcome and control instructions to the Console.
    /// </summary>
    private void PrintInstructions()
    {
        // TODO: Provide simple on-screen or console instructions.
        // Debug.Log("Welcome to the game!");
        // Debug.Log("Use WASD, arrow keys, or the gamepad left stick to move");
        // Debug.Log("Don't bump into objects!");
    }

    /// <summary>
    /// Moves the player cube using either legacy or new input.
    /// </summary>
    private void MovePlayer()
    {
        // TODO: Option A (Legacy):
        // float x = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        // float z = Input.GetAxis("Vertical")   * Time.deltaTime * _moveSpeed;
        // transform.Translate(x, 0f, z);

        // TODO: Option B (New Input System polling, no InputActionAsset):
        // var gamepad  = Gamepad.current;
        // var keyboard = Keyboard.current;
        // Vector3 move = Vector3.zero;
        //
        // if (gamepad != null)
        // {
        //     Vector2 stick = gamepad.leftStick.ReadValue();
        //     move.x = stick.x;
        //     move.z = stick.y;
        // }
        //
        // if (keyboard != null && move == Vector3.zero)
        // {
        //     if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)  move.x = -1f;
        //     if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed) move.x =  1f;
        //     if (keyboard.upArrowKey.isPressed || keyboard.wKey.isPressed)    move.z =  1f;
        //     if (keyboard.downArrowKey.isPressed || keyboard.sKey.isPressed)  move.z = -1f;
        // }
        //
        // transform.Translate(move.normalized * _moveSpeed * Time.deltaTime);
    }

    #endregion
}