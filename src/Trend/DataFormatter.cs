using System.Globalization;
using System.Text;

namespace Trend
{
    /// <summary>
    /// A data formatter with a helper method to format provided data values into a string-formatted matrix.
    /// </summary>
    public static class DataFormatter
    {
        private const string RowPrefix        = "     | ";
        private const string MiddleRowPrefix  = "II = | ";
        private const string NoValuesProvided = "No data values were provided for formatting.";

        /// <summary>
        /// Formats a set of values into a matrix.
        /// </summary>
        /// <param name="c">Integer used to calculate the dimensions of the array</param>
        /// <param name="values">An array of data values that are of type double</param>
        /// <returns>A string representing the data values formatted as a matrix</returns>
        public static string GetValuesFormattedAsMatrix(int c, double[] values)
        {
            if (values.Length == 0)
            {
                return NoValuesProvided;
            }

            var cellIndex    = 0;
            var matrixDimension  = c + 1;
            var numberOfRows = matrixDimension;
            var currentRowNumber    = 1;

            var middleRowNumber = numberOfRows % 2 == 0
                ? numberOfRows / 2
                : numberOfRows / 2 + 1;

            var matrix = new StringBuilder();

            matrix.Append(numberOfRows <= 2 ? MiddleRowPrefix : RowPrefix);

            foreach (var value in values)
            {
                currentRowNumber = AddCellPrefix(cellIndex, matrixDimension, matrix, currentRowNumber, numberOfRows, middleRowNumber, MiddleRowPrefix, RowPrefix);

                //Append the current value to the matrix, ensuring that correct padding is maintained.
                matrix.Append(value.ToString(CultureInfo.InvariantCulture).PadRight(8));

                cellIndex++;
            }

            matrix.Append(" |");
            return matrix.ToString();
        }

        /// <summary>
        /// Adds a prefix before the next cell.
        /// </summary>
        /// <param name="cellIndex"></param>
        /// <param name="matrixWidth"></param>
        /// <param name="sb"></param>
        /// <param name="currentRowNumber"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="middleRowNumber"></param>
        /// <param name="middleRowPrefix"></param>
        /// <param name="rowPrefix"></param>
        /// <returns>The current row number</returns>
        private static int AddCellPrefix(int cellIndex, int matrixWidth, StringBuilder sb, int currentRowNumber,
            int numberOfRows, int middleRowNumber, string middleRowPrefix, string rowPrefix)
        {
            if (cellIndex > 0 &&
                cellIndex % matrixWidth == 0)
            {
                sb.AppendLine(" |");

                currentRowNumber++;

                AddRowPrefix(numberOfRows, currentRowNumber, middleRowNumber, sb, middleRowPrefix, rowPrefix);
            }
            else if (cellIndex > 0)
            {
                sb.Append(" ");
            }

            return currentRowNumber;
        }

        /// <summary>
        /// Adds a prefix to a row, being either the normal or the middle row prefix.
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="rowNumber"></param>
        /// <param name="middleRowNumber"></param>
        /// <param name="sb"></param>
        /// <param name="middleRowPrefix"></param>
        /// <param name="rowPrefix"></param>
        private static void AddRowPrefix(
            int numberOfRows,
            int rowNumber,
            int middleRowNumber,
            StringBuilder sb,
            string middleRowPrefix,
            string rowPrefix)
        {
            if (numberOfRows > 2 &&
                rowNumber == middleRowNumber)
            {
                sb.Append(middleRowPrefix);
            }
            else
            {
                sb.Append(rowPrefix);
            }
        }
    }
}
