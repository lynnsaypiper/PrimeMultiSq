﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeMultiSq.BusinessLogic.Interfaces;

namespace PrimeMultiSq.BusinessLogic
{
    public class GridOutput : IOutput
    {
        public StringBuilder FormatOutput(IEnumerable<int[]> input)
        {
            if(input == null)
                throw new ArgumentNullException(nameof(input));

            var enumerable = input as IList<int[]> ?? input.ToList();

            if(!enumerable.Any())
                throw new ArgumentNullException(nameof(input));

            var grid = new StringBuilder();

            foreach (var row in enumerable)
            {
                grid.AppendLine(FormatRow(row));
            }

            return grid;
        }

        private string FormatRow(int[] row)
        {
            var rowFormatted = new StringBuilder();

            rowFormatted.Append(FormatFirstIndex(row[0]));

            for (int i = 1; i < row.Count(); i++)
            {
                rowFormatted.Append($"  {row[i]}|");
            }

            return rowFormatted.ToString();
        }

        private string FormatFirstIndex(int number)
        {
            return $"|  {number}|";
        }
    }
}
