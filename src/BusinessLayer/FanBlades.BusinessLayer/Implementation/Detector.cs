using Alturos.Yolo;
using Alturos.Yolo.Model;
using FanBlades.BusinessLayer.Abstraction;
using OpenCvSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanBlades.BusinessLayer.Implementation
{
    internal class Detector : IDetector
    {
        private readonly YoloWrapper yoloWrapper;

        public Detector(YoloWrapper yoloWrapper)
        {
            this.yoloWrapper = yoloWrapper;
        }

        public Task<IEnumerable<YoloItem>> Detect(Mat mat)
        {
            return Task.Run(() => yoloWrapper.Detect(mat.ToBytes(".bmp")));
        }
    }
}
