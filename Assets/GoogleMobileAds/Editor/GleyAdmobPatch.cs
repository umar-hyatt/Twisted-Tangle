namespace GoogleMobileAds.Editor
{
    public class GleyAdmobPatch
    {
        public static void SetAdmobAppID(string androidAppId, string iosAppID)
        {
#if USE_ADMOB
            GoogleMobileAdsSettings instance = GoogleMobileAdsSettings.LoadInstance();
            instance.DelayAppMeasurementInit = true;
            instance.GoogleMobileAdsAndroidAppId = androidAppId;
            instance.GoogleMobileAdsIOSAppId = iosAppID;
            UnityEditor.EditorUtility.SetDirty(instance);
#endif
        }
    }
}