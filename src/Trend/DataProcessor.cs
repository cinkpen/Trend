using System;

namespace Trend
{
    /// <summary>
    /// A data processor with a helper method to obtain values calculated from a provided array of data.
    /// </summary>
    public static class DataProcessor
    {
        public static double[] GetCalculatedValuesFromDataArray(double[] data, int c, int n)
        {
            var cellIndex = 0;
            if (data.Length == 0 || n > data.Length)
            {
                return new double[0];
            }

            var endIndex = n - 1;

            var arraySize = (int) Math.Pow(c + 1, 2);
            double[] calculatedValues = new double[arraySize];

            for (var k = 0; k <= c; k++)
            {
                for (var j = 0; j <= c; j++)
                {
                    var cellValue = CalculateCellValue(data, c, endIndex, k, j);

                    calculatedValues[cellIndex] = Math.Round(cellValue, 6);

                    cellIndex++;
                }
            }

            return calculatedValues;
        }

        /// <summary>
        /// Calculates a cell value by iterating from a given start index (c) to a given end index (endIndex).
        /// For each index within this loop, the array value at (index - k) is multiplied by the array value at (index - j).
        /// The result of these multiplications is summed to give a call value.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="c"></param>
        /// <param name="endIndex"></param>
        /// <param name="k"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static double CalculateCellValue(double[] data, int c, int endIndex, int k, int j)
        {
            double cellValue = 0;
            for (var i = c; i <= endIndex; i++)
            {
                var iMinusKValue = data[i - k];
                var iMinusJValue = data[i - j];
                cellValue += (iMinusKValue * iMinusJValue);
            }

            return cellValue;
        }
    }
}
