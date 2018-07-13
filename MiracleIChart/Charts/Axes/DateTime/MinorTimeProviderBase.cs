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
using Openmiracle.MiracleIChart.Common.Auxiliary;

namespace Openmiracle.MiracleIChart.Charts
{
	internal abstract class MinorTimeProviderBase<T> : ITicksProvider<T>
	{
		public event EventHandler Changed;
		protected void RaiseChanged()
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}

		private readonly ITicksProvider<T> provider;
		public MinorTimeProviderBase(ITicksProvider<T> provider)
		{
			this.provider = provider;
		}

		private T[] mayorTicks = new T[] { };
		internal void SetTicks(T[] ticks)
		{
			this.mayorTicks = ticks;
		}

		private double ticksSize = 0.5;
		public ITicksInfo<T> GetTicks(Range<T> range, int ticksCount)
		{
			if (mayorTicks.Length == 0)
				return new TicksInfo<T>();

			ticksCount /= mayorTicks.Length;
			if (ticksCount == 0)
				ticksCount = 2;

			var ticks = mayorTicks.GetPairs().Select(r => Clip(provider.GetTicks(r, ticksCount), r)).
				SelectMany(t => t.Ticks).ToArray();

			var res = new TicksInfo<T>
			{
				Ticks = ticks,
				TickSizes = ArrayExtensions.CreateArray(ticks.Length, ticksSize)
			};
			return res;
		}

		private ITicksInfo<T> Clip(ITicksInfo<T> ticks, Range<T> range)
		{
			var newTicks = new List<T>(ticks.Ticks.Length);
			var newSizes = new List<double>(ticks.TickSizes.Length);

			for (int i = 0; i < ticks.Ticks.Length; i++)
			{
				T tick = ticks.Ticks[i];
				if (IsInside(tick, range))
				{
					newTicks.Add(tick);
					newSizes.Add(ticks.TickSizes[i]);
				}
			}

			return new TicksInfo<T>
			{
				Ticks = newTicks.ToArray(),
				TickSizes = newSizes.ToArray(),
				Info = ticks.Info
			};
		}

		protected abstract bool IsInside(T value, Range<T> range);

		public int DecreaseTickCount(int ticksCount)
		{
			if (mayorTicks.Length > 0)
				ticksCount /= mayorTicks.Length;

			int minorTicksCount = provider.DecreaseTickCount(ticksCount);

			if (mayorTicks.Length > 0)
				minorTicksCount *= mayorTicks.Length;

			return minorTicksCount;
		}

		public int IncreaseTickCount(int ticksCount)
		{
			if (mayorTicks.Length > 0)
				ticksCount /= mayorTicks.Length;

			int minorTicksCount = provider.IncreaseTickCount(ticksCount);

			if (mayorTicks.Length > 0)
				minorTicksCount *= mayorTicks.Length;

			return minorTicksCount;
		}

		public ITicksProvider<T> MinorProvider
		{
			get { return null; }
		}

		public ITicksProvider<T> MayorProvider
		{
			get { return null; }
		}
	}
}
