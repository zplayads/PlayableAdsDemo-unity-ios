using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayableAds.API;

public class CameraController : MonoBehaviour, IPlayableListener, IPlayableAdapterListener
{
	public Text cbInfo;
	public Button requestBtn;
	public Button presentBtn;

	private readonly string iosTestAppId = "iOSDemoApp";
	private readonly string iosTestAdUnitId = "iOSDemoAdUnit";
	private readonly string androidTestAppId = "5C5419C7-A2DE-88BC-A311-C3E7A646F6AF";
	private readonly string androidTestAdUnitId = "BAE5DAAC-04A2-2591-D5B0-38FA846E45E7";

	void Start()
	{
		requestBtn.onClick.AddListener(RequestAd);
		presentBtn.onClick.AddListener(PresentAd);
		PlayableAdsAdapter.Init(gameObject.name, androidTestAppId);
	}


	private void RequestAd()
	{
		cbInfo.text = "request ad";
		#if UNITY_IOS
		PlayableAdsBridge.LoadAd(gameObject.name, iosTestAppId, iosTestAdUnitId);
		#endif

		PlayableAdsAdapter.RequestAd(androidTestAdUnitId);
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

		if(PlayableAdsAdapter.CanPresentAd(androidTestAdUnitId)) {
			PlayableAdsAdapter.PresentAd(androidTestAdUnitId);
		} else {
			cbInfo.text = "ad not ready.";
		}
	}

	#region ios-PlayableAds listener

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

	#region android-PlayableAds listener

	public void OnLoadFinished(string msg)
	{
		cbInfo.text = "load finished";
	}

	public void OnLoadFailed(string msg)
	{
		cbInfo.text = "load failed: " + msg;
	}

	public void PlayableAdsIncentive(string msg)
	{
		cbInfo.text = "PlayableAdsIncentive";
	}

	public void OnPresentError(string msg)
	{
		cbInfo.text = "OnPresentError: " + msg;
	}

	public void PlayableAdsMessage(string msg)
	{
		cbInfo.text = "PlayableAdsMessage: " +msg;
	}

	#endregion
}
