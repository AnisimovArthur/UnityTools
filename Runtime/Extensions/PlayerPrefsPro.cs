using System;

using UnityEngine;

namespace UnityTools
{
    public static class PlayerPrefsPro
    {
        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public static bool GetBool(string key, bool defaultValue = false)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        public static void SetDateTime(string key, DateTime dateTime)
        {
            PlayerPrefs.SetString(key, dateTime.Ticks.ToString());
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        public static DateTime GetDateTime(string key, DateTime defaultValue)
        {
            if (long.TryParse(PlayerPrefs.GetString(key), out long ticks))
            {
                return new DateTime(ticks);
            }

            return defaultValue;
        }
    }
}
