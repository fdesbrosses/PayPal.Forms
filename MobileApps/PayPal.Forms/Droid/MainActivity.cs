﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PayPal.Forms.Abstractions;

namespace PayPal.Forms.Test.Droid
{
	[Activity (Label = "PayPal.Forms.Test.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			Forms.CrossPaypalManager.Init (
				new PayPalConfiguration (
					PayPal.Forms.Abstractions.Enum.Environment.NoNetwork,
					"ATdpUY5hE7rhrNmDnKjJLTD2NkyNRjEO7oq62DJdthmFjENBKKottH1AtXqr4Yatkcaj9GGdrJcZOYtL"
				){
					AcceptCreditCards = true,
					MerchantName = "Test Store",
					MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
					MerchantUserAgreementUri = "https://www.example.com/legal"
				}
			);

			LoadApplication (new App ());
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			PayPalManagerImplementation.Manager.OnActivityResult (requestCode, resultCode, data);
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			PayPalManagerImplementation.Manager.Destroy ();
		}
	}
}
