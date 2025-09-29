#region Header
// Hazard3D.cs
// Author: James LaFritz
// Description: Collision-based hazard with time penalty, visual feedback, and optional reset.
// Notes: OnCollisionEnter requires a non-kinematic Rigidbody on at least one collider.
#endregion

using UnityEngine;
using DeadlyDodge.Core;

namespace DeadlyDodge.Gameplay
{
    /// <summary>
    /// A collision-based hazard that subtracts time on contact, marks itself as "Hit",
    /// and optionally resets after a cooldown. Visual feedback is provided by tinting
    /// the object's material color on hit and restoring it on reset.
    ///
    /// <para><b>Physics:</b>
    /// Requires a non-kinematic Rigidbody on the <em>player</em> (recommended).
    /// Hazards can be static colliders without a Rigidbody.
    /// </para>
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class Hazard3D : MonoBehaviour
    {
        static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        static readonly int ColorId = Shader.PropertyToID("_Color");

        #region Fields

        /// <summary>
        /// Time penalty (seconds) to subtract from the run timer when the player collides.
        /// </summary>
        [SerializeField, Min(0f)] private float _timePenaltySeconds = 3f;

        /// <summary>
        /// If true, the hazard only penalizes once (stays in "Hit" state).
        /// If false, the hazard resets after <see cref="_resetCooldownSeconds"/>.
        /// </summary>
        [SerializeField] private bool _oneShot;

        /// <summary>
        /// Cooldown (seconds) before the hazard resets (only used if <see cref="_oneShot"/> is false).
        /// </summary>
        [SerializeField, Min(0f)] private float _resetCooldownSeconds = 2.5f;

        /// <summary>
        /// Color used to tint the material while the hazard is in the "Hit" state.
        /// </summary>
        [SerializeField] private Color _hitColor = Color.red;

        /// <summary>
        /// Optional Renderer to tint on hit. If null, the first Renderer on this GameObject is used.
        /// </summary>
        [SerializeField] private Renderer _rendererOverride;

        /// <summary>
        /// Cached reference to the Renderer being modified.
        /// </summary>
        private Renderer _renderer;

        /// <summary>
        /// Original material color cached at startup (so we can restore it on reset).
        /// </summary>
        private Color _originalColor = Color.white;

        /// <summary>
        /// True while in cooldown (or permanently if oneShot is enabled, and we have been hit).
        /// </summary>
        private bool _isInCooldown;

        /// <summary>
        /// Time (absolute) when cooldown ends and the hazard can be hit again.
        /// </summary>
        private float _reactivateAt;
        
        /// <summary>
        /// Reusable material property block for per-instance color overrides.
        /// </summary>
        private MaterialPropertyBlock _mpb;

        #endregion

        #region Unity Messages

        /// <summary>
        /// Caches renderer/color and original tag.
        /// </summary>
        private void Awake()
        {
            _renderer = _rendererOverride != null
                ? _rendererOverride
                : GetComponent<Renderer>();

            // If there is a renderer, cache the initial color from a per-instance material.
            if (_renderer != null)
            {
                _originalColor = GetColor();
            }
        }

        /// <summary>
        /// Collision entry point that subtracts time, marks the hazard as hit, and optionally schedules a reset.
        /// </summary>
        /// <param name="collision">Collision information from the physics system.</param>
        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"{collision.gameObject.tag} has hit: " + gameObject.name);
            if (_isInCooldown) return;
            if (!collision.collider.CompareTag("Player")) return;

            Hit();
        }

        /// <summary>
        /// Drives the cooldown timer when in reset mode.
        /// </summary>
        private void Update()
        {
            if (!_oneShot && _isInCooldown && Time.time >= _reactivateAt)
            {
                ResetHazard();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Applies penalty, visual feedback, and state changes as if the player collided.
        /// Can be called from <c>OnControllerColliderHit</c> on the player when using CharacterController.
        /// </summary>
        private void Hit()
        {
            // 1) Apply the time penalty.
            var timer = FindAnyObjectByType<RunTimer>();
            timer?.ApplyPenalty(_timePenaltySeconds);

            // 2) Register a "hit" for scoring.
            var score = FindAnyObjectByType<ScoreSystem>();
            score?.RegisterHit();

            // 3) Visual feedback: tint color and set tag = "Hit".
            SetHitVisuals();
            
            _isInCooldown = true;
            _reactivateAt = _oneShot ? float.PositiveInfinity : Time.time + _resetCooldownSeconds;
        }

        /// <summary>
        /// Applies "Hit" state visuals and tag.
        /// </summary>
        private void SetHitVisuals()
        {
            // Tint the instance material if we have a renderer and a color property.
            SetColor(_hitColor);
        }

        /// <summary>
        /// Restores the original tag and material color, making the hazard hittable again.
        /// </summary>
        private void ResetHazard()
        {
            // Restore color.
            SetColor(_originalColor);

            _isInCooldown = false;
        }

        /// <summary>
        /// Reads the renderer's current base color, defaulting to white when no property is present.
        /// </summary>
        /// <returns>The resolved color applied to the renderer.</returns>
        private Color GetColor() {
            var color = Color.white;
            if (!_renderer) return color;
        
            var m = _renderer.sharedMaterial;
            if (!m) return color;
        
            if (m.HasProperty(BaseColorId)) return m.GetColor(BaseColorId);
            return m.HasProperty(ColorId) ? m.GetColor(ColorId) : color;
        }

        /// <summary>
        /// Applies a per-instance color override using a material property block.
        /// </summary>
        /// <param name="color">Color to assign to the renderer.</param>
        private void SetColor(Color color) {
            if (!_renderer) return;
        
            var m = _renderer.sharedMaterial;
            if (!m) return;
        
            _mpb ??= new MaterialPropertyBlock();
            _renderer.GetPropertyBlock(_mpb);

            if (m.HasProperty(BaseColorId)) {
                _mpb.SetColor(BaseColorId, color);
            }
            else if (m.HasProperty(ColorId)) {
                _mpb.SetColor(ColorId, color);
            }
        
            _renderer.SetPropertyBlock(_mpb);
        }

        #endregion
    }
}

