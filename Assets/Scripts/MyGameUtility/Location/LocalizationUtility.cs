using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace MyGameUtility.Location {
    public static class LocalizationUtility {
        private static LocalizedStringTable _DefaultLocalizedStringTable = new LocalizedStringTable(LocalizationSettings.StringDatabase.DefaultTable);

        public static LocalizedStringTable LocalizedStringTable => _DefaultLocalizedStringTable;
        
        public static string GetLocalizedString<T>(this T original) {
            try {
                if (original is System.Enum enumValue) {
                    return LocalizationSettings.StringDatabase.GetLocalizedString(StringUtility.Connect(string.Empty, "Enum_", typeof(T).FullName, ".", enumValue.ToString()));
                }
                else if (original is System.String stringValue) {
                    return LocalizationSettings.StringDatabase.GetLocalizedString(StringUtility.Connect(string.Empty, "String_", stringValue));
                }
            }
            catch (Exception e) {
                Debug.LogException(e);
                return original.ToString();
            }
            throw new NotImplementedException();
        }
    }
}