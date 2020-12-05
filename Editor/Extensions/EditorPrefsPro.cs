using System;

using UnityEditor;

namespace UnityTools.Editor
{
    public static class EditorPrefsPro
    {
        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        public static void SetBool(string key, bool value)
        {
            EditorPrefs.SetInt(key, value ? 1 : 0);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public static bool GetBool(string key, bool defaultValue = false)
        {
            return EditorPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        public static void SetDateTime(string key, DateTime dateTime)
        {
            EditorPrefs.SetString(key, dateTime.Ticks.ToString());
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public static DateTime GetDateTime(string key, DateTime defaultValue)
        {
            if (long.TryParse(EditorPrefs.GetString(key), out long ticks))
            {
                return new DateTime(ticks);
            }

            return defaultValue;
        }
    }
}
