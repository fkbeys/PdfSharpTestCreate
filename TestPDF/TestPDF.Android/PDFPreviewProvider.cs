﻿using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using Android.Content.PM;
using Xamarin.Forms;
using TestPDF.Droid;

[assembly: Dependency(typeof(PDFPreviewProvider))]
namespace TestPDF.Droid
{
    public class PDFPreviewProvider : IPDFPreviewProvider
    {
        public PDFPreviewProvider()
        {
        }

        public void TriggerPreview(string path)
        {
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(path));
            intent.SetType("application/pdf");
            IList<ResolveInfo> activities = Android.App.Application.Context.ApplicationContext.PackageManager.QueryIntentActivities(intent, 0);
            if (activities.Count > 0)
            {
                Android.App.Application.Context.ApplicationContext.StartActivity(intent);
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context.ApplicationContext, string.Format("There is no default PDF viewer found, please download and open the file manually from {0}", path), ToastLength.Long).Show();
            }
        }

    }
}