using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using SharingIsCaring.Droid.Dependencies;
using Android.Content.Res;
using System.IO;

namespace SharingIsCaring.Droid
{
    [Activity(Label = "SharingIsCaring", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            SaveFilesFromAssets("Lombre.png");
            SaveFile("testHTML.html");
            SaveFile("testPDF.pdf");
            //SaveFilesFromAssets("testPDF.pdf");
            LoadDependencies();

            LoadApplication(new App());
        }

        void LoadDependencies(){
            DependencyService.Register<FileStore>();
            DependencyService.Register<Share>();
        }

        //Save Image
        void SaveFilesFromAssets(string fileName){

            //Read and save all files from Asserts
            using (var stream = Assets.OpenFd(fileName))
            using (var readStream = Assets.Open(fileName))
            using (var memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[stream.Length];
                int read;
                while((read = readStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }

                var data = memoryStream.ToArray();
                var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, fileName);
                System.IO.File.WriteAllBytes(path, data);
            }

        }

        //Save PDF
        void SaveFile(string fileName){
            var test = Assets.Open(fileName);
            var filePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamWriter write = new System.IO.StreamWriter(filePath, true))
                {
                    write.Write(test);
                }
            }
        }
    }
}