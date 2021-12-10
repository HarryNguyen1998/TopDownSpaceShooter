using System;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Credits from https://www.youtube.com/watch?v=lRqR4YF8iQs
/// </summary>

namespace Utils
{
    public static class LoggerWrapper
    {
        static void DoLog(Action<string, Object> logFunc, string prefix, Object obj, params object[] msg)
        {
#if UNITY_EDITOR
            logFunc($"{prefix}[<color=#ffa500ff>{obj.name}</color>]: {String.Join(",", msg)}", obj);
#endif
        }

        public static void Log(this Object obj, params object[] msg)
        {
            DoLog(Debug.Log, "", obj, msg);
        }

        public static void LogError(this Object obj, params object[] msg)
        {
            DoLog(Debug.LogError, $"<color=red>\u2622</color>", obj, msg);
        }

        public static void LogWarning(this Object obj, params object[] msg)
        {
            DoLog(Debug.LogWarning, $"<color=yellow>\u26a0</color>", obj, msg);
        }

        public static void LogSuccess(this Object obj, params object[] msg)
        {
            DoLog(Debug.Log, $"<color=green>\u2714</color>", obj, msg);
        }

    }
}
