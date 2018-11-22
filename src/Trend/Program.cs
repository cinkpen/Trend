using System;

namespace Trend
{
    class Program
    {
        /// <summary>
        /// Entry point to this application.
        /// Three arguments are required, namely a file name where data values are held and two integers.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            if (!AreArgumentsValid(args))
            {
                Console.Write("Three arguments are required - a file name and two integers");
                return;
            }

            var c = int.Parse(args[1]);
            var n = int.Parse(args[2]);
            var fileName = args[0];

            var dataValues = DataProvider.GetDataValuesFromFile(fileName);

            var calculatedValues = DataProcessor.GetCalculatedValuesFromDataArray(dataValues, c, n);

            var formattedMatrix = DataFormatter.GetValuesFormattedAsMatrix(c, calculatedValues);

            Console.Write(formattedMatrix);
        }

        /// <summary>
        /// Checks that 3 arguments of the corect type have been provided.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool AreArgumentsValid(string[] args)
        {
            if (args == null || args.Length != 3)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(args[0]))
            {
                return false;
            }

            if (!int.TryParse(args[1], out _))
            {
                return false;
            }

            if (!int.TryParse(args[2], out _))
            {
                return false;
            }

            return true;
        }
    }
}
