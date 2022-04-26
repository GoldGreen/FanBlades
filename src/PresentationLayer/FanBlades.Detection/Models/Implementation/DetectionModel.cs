using Alturos.Yolo.Model;
using FanBlades.BusinessLayer.Abstraction;
using FanBlades.Detection.Models.Abstraction;
using OpenCvSharp;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FanBlades.Detection.Models.Implementation
{
    internal class DetectionModel : ReactiveObject, IDetectionModel
    {
        private readonly IDetector detector;
        private readonly ILogger logger;

        public ObservableCollection<TimedYoloItem> CurrentSessionYoloItems { get; } = new();

        public DetectionModel(IDetector detector, ILogger logger)
        {
            this.detector = detector;
            this.logger = logger;
        }

        public async Task<(IEnumerable<YoloItem>, Mat)> Detect(string fileName)
        {
            Mat mat = new(fileName);
            var items = await detector.Detect(mat);
            var dateTime = DateTime.Now;
            string shortFileName = Path.GetFileName(fileName);

            var wrappedItems = items.Select(x => new TimedYoloItem(dateTime, shortFileName, x)).ToList();
            CurrentSessionYoloItems.AddRange(wrappedItems);

            foreach (var wrapedItem in wrappedItems)
            {
                logger.Information("Файл: {file}; класс: {class}; точность: {confidence}; прямоугольник: (x:{x} y:{y} ширина: {width} высота: {height})",
                                   shortFileName,
                                   wrapedItem.YoloItem.Type,
                                   wrapedItem.YoloItem.Confidence,
                                   wrapedItem.YoloItem.X,
                                   wrapedItem.YoloItem.Y,
                                   wrapedItem.YoloItem.Width,
                                   wrapedItem.YoloItem.Height);
            }

            return (items, mat);
        }

        public void Draw(Mat mat, IEnumerable<YoloItem> detectedItems)
        {
            foreach (var detectedItem in detectedItems)
            {
                if (detectedItem.Type == "lopatka")
                {
                    Cv2.Rectangle(mat,
                                  new Rect(detectedItem.X,
                                           detectedItem.Y,
                                           detectedItem.Width,
                                           detectedItem.Height),
                                  Scalar.Blue,
                                  20);
                }
                else if (detectedItem.Type == "carapina")
                {
                    Cv2.Ellipse(mat,
                                new Point(detectedItem.X + detectedItem.Width / 2,
                                          detectedItem.Y + detectedItem.Height / 2),
                                new Size(detectedItem.Width,
                                         detectedItem.Height),
                                0,
                                0,
                                360,
                                Scalar.Red,
                                10);
                }
            }
        }
    }
}
