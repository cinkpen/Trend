using System.Collections.Generic;
using System.IO;

namespace Trend
{
    /// <summary>
    /// A data provider with a helper method that returns an array of doubles from a given file.
    /// </summary>
    public static class DataProvider
    {
        public static double[] GetDataValuesFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new double[0];
            }

            List<double> dataValues = new List<double>();

            var sr = new StreamReader(fileName);

            var i        = 0;
            var dataLine = sr.ReadLine();

            while (dataLine != null)
            {
                if (double.TryParse(dataLine, out var dataValue))
                {
                    dataValues.Add(dataValue);
                    i++;
                }

                dataLine = sr.ReadLine();
            }

            sr.Close();

            return dataValues.ToArray();
        }
    }
}
