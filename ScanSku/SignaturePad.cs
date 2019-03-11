using System.IO;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;

using Xamarin.Controls;

using static ScanSKU.ScanSKUDataBase;

namespace ScanSKU
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class SignaturPadActivity : AppCompatActivity
    {
        private System.Drawing.PointF[] points;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_signature_pad);

            var signatureView = FindViewById<SignaturePadView>(Resource.Id.signatureView);

            var btnSave = FindViewById<Button>(Resource.Id.btnSave);
            var btnLoad = FindViewById<Button>(Resource.Id.btnLoad);
            var btnSaveImage = FindViewById<Button>(Resource.Id.btnSaveImage);

            btnSave.Click += delegate
            {
                points = signatureView.Points;

                Toast.MakeText(this, "Vector signature saved to memory.", ToastLength.Short).Show();
            };

            btnLoad.Click += delegate
            {
                if (points != null)
                    signatureView.LoadPoints(points);
            };

            btnSaveImage.Click += async delegate
            {



                DataUpload ds = new DataUpload();
                



                var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures).AbsolutePath;
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted ||
               ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted)
                {
                    Context mContext = Application.Context;
                    AppPreferences applicationPreferences = new AppPreferences(mContext);
                    string batch = applicationPreferences.GetAccessKey("batchnumber");
                    var file = System.IO.Path.Combine(path, batch + ".jpg");

                    using (var bitmap = await signatureView.GetImageStreamAsync(SignatureImageFormat.Jpeg, Color.Black, Color.White, 1f))
                    using (var dest = File.OpenWrite(file))
                    {
                        await bitmap.CopyToAsync(dest);
                    }

                    Toast.MakeText(this, "Raster signature saved to the photo gallery.", ToastLength.Short).Show();
                }
            };
        }
    }
}
