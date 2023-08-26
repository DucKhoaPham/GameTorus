using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class Advertise : MonoBehaviour {
	public GameObject GM;
	public GameObject DataGame;
	bool valid;
	bool valid2;
	public int count;
	private BannerView bannerView;
	private InterstitialAd  interstitial;
	// Use this for initialization

	void Start () {
		count = Data.Instance.count;
		valid = true;
		valid2 = true;
		Debug.Log (count);


	}
	// Update is called once per frame
	void Update () {
		
		Advertising ();
	}
	private void RequestBanner()
	{
		string adUnitId = "ca-app-pub-8514036858698162/5270370732";

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
	}

	private void RequestInterstitial()
	{
		string adUnitId = "ca-app-pub-8514036858698162/9700570332";


		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()

				.TagForChildDirectedTreatment(false)
				.AddExtra("color_bg", "9B30FF")
				.Build();
	}

	void Advertising(){
		if (GM.GetComponent<GameManager> ().Stategame () == GameManager.GameManagerState.Opening && count % 2 == 0 && count != 0 && valid == true) {
				RequestInterstitial ();
				Interest ();
			}
		if (GM.GetComponent<GameManager> ().Stategame () == GameManager.GameManagerState.Opening && valid2 == true) {
			RequestBanner ();
			bannerView.Show();
			valid2 = false;
		}
	}
		
		public void Clickplay()
		{
			bannerView.Destroy ();
			count++;
			valid = true;
			valid2 = true;
			Data.Instance.count = count;
		}

	void Interest(){
		if(interstitial.IsLoaded ())
			interstitial.Show ();
		while (!interstitial.IsLoaded ()) {
			if(interstitial.IsLoaded ())
				interstitial.Show ();
				
			}
		valid = false;
	}

	public void HandleAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}

	void HandleAdClosing(object sender, EventArgs args)
	{
		print("HandleAdClosing event received");
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}
		

	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		print("HandleInterstitialLoaded event received.");
	}

	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}

	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		print("HandleInterstitialOpened event received");
	}

	void HandleInterstitialClosing(object sender, EventArgs args)
	{
		print("HandleInterstitialClosing event received");
	}

	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		print("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		print("HandleInterstitialLeftApplication event received");
	}
		
}
