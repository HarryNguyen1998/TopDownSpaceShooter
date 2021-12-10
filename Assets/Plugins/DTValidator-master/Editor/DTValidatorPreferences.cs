using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace DTValidator {
	public static class DTValidatorPreferences {
		public static bool ValidateSceneAutomatically {
			get { return EditorPrefs.GetBool("DTValidatorPreferences::ValidateSceneAutomatically", defaultValue: false); }
			set { EditorPrefs.SetBool("DTValidatorPreferences::ValidateSceneAutomatically", value); }
		}

        private class MyPrefSettingsProvider : SettingsProvider
        {
            public MyPrefSettingsProvider(string path, SettingsScope scopes = SettingsScope.User) :
            base(path, scopes)
            { }

            public override void OnGUI(string searchContext)
            {
                PreferencesGUI();
            }
        }

        [SettingsProvider]
        static SettingsProvider NewPreferencesGUI()
        {
            return new MyPrefSettingsProvider("Preferences/DTValidator");
        }

		public static void PreferencesGUI()
        {
			ValidateSceneAutomatically = EditorGUILayout.Toggle("Validate Scene Automatically", ValidateSceneAutomatically);
		}
	}
}
