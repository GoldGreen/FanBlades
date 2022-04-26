using Alturos.Yolo.Model;
using System;

namespace FanBlades.Detection.Models
{
    internal record TimedYoloItem(DateTime DateTime, string FileName, YoloItem YoloItem);
}
