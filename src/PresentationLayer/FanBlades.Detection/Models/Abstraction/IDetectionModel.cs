using Alturos.Yolo.Model;
using OpenCvSharp;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FanBlades.Detection.Models.Abstraction
{
    internal interface IDetectionModel : IReactiveObject
    {
        ObservableCollection<TimedYoloItem> CurrentSessionYoloItems { get; }

        Task<(IEnumerable<YoloItem>, Mat)> Detect(string fileName);
        void Draw(Mat mat, IEnumerable<YoloItem> detectedItems);
    }
}
