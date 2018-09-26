using System;
using System.ComponentModel;
using System.Windows.Input;
using SharingIsCaring.Dependencies;
using Xamarin.Forms;

namespace SharingIsCaring.ViewModels
{
	public class MainPageViewModel: INotifyPropertyChanged
    {
        public ICommand BtnClickCommand { protected set; get; }

        public MainPageViewModel()
        {
			BtnClickCommand = new Command<string>((key) =>{
				ShareBtnClicked(key);
			});
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void ShareBtnClicked(string param)
        {
            var test = DependencyService.Get<IFileStore>();
            var filePath = test.GetFilePath(param);
            var share = DependencyService.Get<IShare>();
            share.Show("Title", param, filePath);
        }
    }
}
