namespace FanBlades.BusinessLayer.Configuration
{
    internal class DetectorOption
    {
        public const string Detector = nameof(Detector);

        public string ClassesPath { get; set; }
        public string ConfigPath { get; set; }
        public string WeightPath { get; set; }
    }
}
