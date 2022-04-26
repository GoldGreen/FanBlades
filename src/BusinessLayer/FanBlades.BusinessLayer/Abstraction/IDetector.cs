using Alturos.Yolo.Model;
using OpenCvSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanBlades.BusinessLayer.Abstraction
{
    public interface IDetector
    {
        Task<IEnumerable<YoloItem>> Detect(Mat mat);
    }
}
