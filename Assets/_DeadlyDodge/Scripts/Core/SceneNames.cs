#region Header
// SceneNames.cs
// Author: James LaFritz
// Description: Centralized scene name constants to avoid typos in loads.
#endregion

namespace DeadlyDodge.Core
{
    /// <summary>
    /// Centralized scene name constants used by the MVP flow.
    /// </summary>
    public static class SceneNames
    {
        /// <summary>Title scene name.</summary>
        public const string Title = "Title";

        /// <summary>Controls scene name.</summary>
        public const string Controls = "Controls";

        /// <summary>Game scene name.</summary>
        public const string Game = "Game";

        /// <summary>GameOver scene name (optional if using overlay).</summary>
        public const string GameOver = "GameOver";
    }
}