using UnityEngine;
using UnityEngine.UI;
using PlayableAds.API;

public class CameraController : MonoBehaviour, IPlayableListener
{
	public Text cbInfo;
	public Button requestBtn;
	public Button presentBtn;

	private readonly string iOSTestAppId = "iOSDemoApp";
	private readonly string iOSTestAdUnitId = "iOSDemoAdUnit";

	void Start()
	{
		requestBtn.onClick.AddListener(RequestAd);
		presentBtn.onClick.AddListener(PresentAd);
	}


	private void RequestAd()
	{
		cbInfo.text = "request ad";
		#if UNITY_IOS
		PlayableAdsBridge.LoadAd(gameObject.name, iOSTestAppId, iOSTestAdUnitId);
		#endif
	}

	private void PresentAd()
	{
		cbInfo.text = "present ad";
		#if UNITY_IOS
		if(PlayableAdsBridge.IsReady()) {
		PlayableAdsBridge.PresentAd();
		} else {
		cbInfo.text = "ad not ready.";
		}
		#endif
	}

	#region PlayableAds listener
	// Reward
	public void PlayableAdsDidRewardUser(string msg)
	{
		cbInfo.text = "PlayableAdsDidRewardUser";
	}

	// ad has been loaded.
	public void PlayableAdsDidLoad(string msg)
	{
		cbInfo.text = "PlayableAdsDidLoad";
	}

	// ad load failed
	public void DidFailToLoadWithError(string error)
	{
		cbInfo.text = error;
	}

	// playable other feedback
	public void PlayableAdFeedBack(string msg)
	{
		Debug.Log("PlayableAdFeedBack: " + msg);
	}
	#endregion
}
