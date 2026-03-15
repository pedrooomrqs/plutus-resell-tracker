using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace Tracker
{
    public class DataManager
    {
        private string filePath = "data.json";
        private string bumpsFilePath = "bumps.json";
        private string oldBumpsFilePath = "bumps.txt";

        public void Save(List<ResellItem> items)
        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(filePath, json);
        }

        public List<ResellItem> Load()
        {
            if (!File.Exists(filePath))
                return new List<ResellItem>();

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<ResellItem>();

            List<ResellItem> items = JsonSerializer.Deserialize<List<ResellItem>>(json);
            return items ?? new List<ResellItem>();
        }

        public void SaveBumps(List<double> bumps)
        {
            var json = JsonSerializer.Serialize(bumps);
            File.WriteAllText(bumpsFilePath, json);
        }

        public List<double> LoadBumps()
        {
            if (File.Exists(bumpsFilePath))
            {
                string json = File.ReadAllText(bumpsFilePath);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<double>();

                List<double> bumps = JsonSerializer.Deserialize<List<double>>(json);
                return bumps ?? new List<double>();
            }

            if (File.Exists(oldBumpsFilePath))
            {
                string text = File.ReadAllText(oldBumpsFilePath);

                if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double oldValue) && oldValue > 0)
                    return new List<double> { oldValue };
            }

            return new List<double>();
        }
    }
}