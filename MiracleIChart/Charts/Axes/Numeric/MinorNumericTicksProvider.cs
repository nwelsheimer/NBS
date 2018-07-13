//This is a source code or part of OpenMiracle project
//Copyright (C) 2013 OpenMiracle
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with this program. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Openmiracle.MiracleIChart.Charts
{
	public sealed class MinorNumericTicksProvider : ITicksProvider<double>
	{
		private readonly ITicksProvider<double> parent;
		private Range<double>[] ranges;
		internal void SetRanges(IEnumerable<Range<double>> ranges)
		{
			this.ranges = ranges.ToArray();
		}

		public double[] Coeffs { get; set; }

		internal MinorNumericTicksProvider(ITicksProvider<double> parent)
		{
			this.parent = parent;
			Coeffs = new double[] { };
		}

		#region ITicksProvider<double> Members

		public event EventHandler Changed;
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void RaiseChanged()
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}

		public ITicksInfo<double> GetTicks(Range<double> range, int ticksCount)
		{
			if (Coeffs.Length == 0)
				return new TicksInfo<double>();

			var minorTicks = ranges.Select(r => CreateTicks(r)).SelectMany(m => m);
			var res = new TicksInfo<double>();
			res.TickSizes = minorTicks.Select(m => m.Value).ToArray();
			res.Ticks = minorTicks.Select(m => m.Tick).ToArray();

			return res;
		}

		public MinorTickInfo<double>[] CreateTicks(Range<double> range)
		{
			double step = (range.Max - range.Min) / (Coeffs.Length + 1);

			MinorTickInfo<double>[] res = new MinorTickInfo<double>[Coeffs.Length];
			for (int i = 0; i < Coeffs.Length; i++)
			{
				res[i] = new MinorTickInfo<double>(Coeffs[i], range.Min + step * (i + 1));
			}
			return res;
		}

		public int DecreaseTickCount(int ticksCount)
		{
			return ticksCount;
		}

		public int IncreaseTickCount(int ticksCount)
		{
			return ticksCount;
		}

		public ITicksProvider<double> MinorProvider
		{
			get { throw new NotSupportedException(); }
		}

		public ITicksProvider<double> MayorProvider
		{
			get { return parent; }
		}

		#endregion
	}
}
