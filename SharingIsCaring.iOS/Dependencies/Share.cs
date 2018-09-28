using System.Threading.Tasks;
using Foundation;
using SharingIsCaring.Dependencies;
using UIKit;

namespace SharingIsCaring.iOS.Dependencies
{
    public class Share : IShare
    {
        string filePath;
        private UIDocumentInteractionController _openInWindow;

        public async Task Show(string title, string message, string filePath)
        {
            var fromFile = NSUrl.FromFilename( filePath);
            var items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(filePath) }; 

            var activityController = new UIActivityViewController(items, null);
            var vc = GetTopViewController();


            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                if (activityController.PopoverPresentationController != null)
                {
                    activityController.PopoverPresentationController.SourceView = vc.View;
                }
            }

            await vc.PresentViewControllerAsync(activityController, true);
        }

        UIViewController GetTopViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
                return ((UINavigationController)rootController.PresentedViewController).TopViewController;

            if (rootController.PresentedViewController is UITabBarController)
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;

            return rootController.PresentedViewController;
        }

    }
}
