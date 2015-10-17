using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel.Common;
using Microsoft.Win32;

namespace DotNetBay.WPF.ViewModel
{
    class SellViewModel : ViewModelBase
    {
        private readonly IAuctionService auctionService;
        private readonly IMemberService memberService;

        private string filePathToImage;

        public SellViewModel(IMemberService memberService, IAuctionService auctionService)
        {
            this.auctionService = auctionService;
            this.memberService = memberService;

            this.SelectImageFileCommand = new RelayCommand(this.SelectFolderAction);
            this.CloseDialogCommand = new RelayCommand<Window>(this.CloseAction);
            this.AddAuctionAndCloseCommand = new RelayCommand<Window>(this.AddActionAndClose);

            // Default Values
            this.StartDateTimeUtc = DateTime.UtcNow.AddMinutes(1);
            this.EndDateTimeUtc = DateTime.UtcNow.AddDays(7);
        }

        public string Title
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public double StartPrice
        {
            get; set;
        }

        public DateTime StartDateTimeUtc
        {
            get; set;
        }

        public DateTime EndDateTimeUtc
        {
             get; set;
        }

        public string Image
        {
            get; set;
        }
        public ICommand CloseDialogCommand { get; set; }

        public ICommand AddAuctionAndCloseCommand { get; private set; }

        public ICommand SelectImageFileCommand { get; private set; }


        public string FilePathToImage
        {
            get { return this.filePathToImage; }
            set
            {
                this.Set(() => this.FilePathToImage, ref this.filePathToImage, value);
            }
        }

        private void AddActionAndClose(Window window)
        {
            var newAuction = new Auction()
            {
                Title = this.Title,
                Description = this.Description,
                StartPrice = this.StartPrice,
                StartDateTimeUtc = this.StartDateTimeUtc,
                EndDateTimeUtc = this.EndDateTimeUtc,
                Seller = this.memberService.GetCurrentMember(),
            };

            if (!string.IsNullOrEmpty(this.FilePathToImage))
            {
                newAuction.Image = File.ReadAllBytes(this.FilePathToImage);
            }

            this.auctionService.Save(newAuction);

            window.Close();
        }

        private void SelectFolderAction()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true && File.Exists(openFileDialog.FileName))
            {
                var fileInfo = new FileInfo(openFileDialog.FileName);
                if (fileInfo.Extension.EndsWith("jpg"))
                {
                    this.FilePathToImage = openFileDialog.FileName;
                }
            }
        }

        private void CloseAction(Window window)
        {
            window.Close();
        }

    }
}
