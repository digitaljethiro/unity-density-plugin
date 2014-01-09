using UnityEngine;
using System.Runtime.InteropServices;

public class Density
{
	public static float Value { get; protected set; }

	#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern float IOSDensity_ ();
	#endif

	static Density ()
	{
		Value = 1.0f;
		#if UNITY_ANDROID
		using (
			AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"),
			metricsClass = new AndroidJavaClass("android.util.DisplayMetrics")
			) {
			using (
				AndroidJavaObject metricsInstance = new AndroidJavaObject("android.util.DisplayMetrics"),
				activityInstance = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity"),
				windowManagerInstance = activityInstance.Call<AndroidJavaObject>("getWindowManager"),
				displayInstance = windowManagerInstance.Call<AndroidJavaObject>("getDefaultDisplay")
				) {
				displayInstance.Call ("getMetrics", metricsInstance);
				Value = metricsInstance.Get<float> ("density");
			}
		}
		#endif
		#if UNITY_IPHONE
		if (Application.platform != RuntimePlatform.OSXEditor) {
			Value = IOSDensity_ ();
		}
		#endif
	}
}
