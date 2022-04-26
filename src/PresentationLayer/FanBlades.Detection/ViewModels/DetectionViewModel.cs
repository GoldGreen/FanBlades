using FanBlades.Detection.Models.Abstraction;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using OpenCvSharp.WpfExtensions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace FanBlades.Detection.ViewModels
{
    internal class DetectionViewModel : ReactiveObject
    {
        private readonly ILogger logger;
        public SnackbarMessageQueue Queue { get; } = new(TimeSpan.FromSeconds(2))
        {
            DiscardDuplicates = false
        };
        public IDetectionModel Model { get; }
        [Reactive] public ImageSource Image { get; set; }

        public ICommand OpenFileCommand { get; }

        public DetectionViewModel(IDetectionModel model, ILogger logger)
        {
            Model = model;
            this.logger = logger;
            OpenFileCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Filter = "Файлы изображений (*.bmp,*.jpg,*.jpeg,*.png)|*.bmp;*.jpg;*.jpeg;*.png|Все файлы (*.*)|*.*";
                if (openFileDialog.ShowDialog() != true)
                {
                    return;
                }

                try
                {
                    (var detectedItems, var mat) = await Model.Detect(openFileDialog.FileName);
                    Model.Draw(mat, detectedItems);
                    Image = mat.ToBitmapSource();
                    mat.Dispose();
                }
                catch (Exception e)
                {
                    this.logger.Error("Не удалось открыть файл: {fileName}, исключение: {exception}", openFileDialog.FileName, e.Message);
                    Queue.Enqueue(e.Message, "OK", actionHandler: null);
                }
            });
        }
    }
}
