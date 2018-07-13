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
using System.Diagnostics;
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	[DebuggerDisplay("Count = {Count}")]
	internal sealed class FakePointList : IList<Point> {
		private int first;
		private int last;
		private int count;
		private Point startPoint;
		private bool hasPoints;

		private double leftBound;
		private double rightBound;
		private readonly List<Point> points;

		internal FakePointList(List<Point> points, double left, double right) {
			this.points = points;
			this.leftBound = left;
			this.rightBound = right;

			Calc();
		}

		internal void SetXBorders(double left, double right) {
			this.leftBound = left;
			this.rightBound = right;
			Calc();
		}

		private void Calc() {
			Debug.Assert(leftBound <= rightBound);

			first = points.FindIndex(p => p.X > leftBound);
			if (first > 0)
				first--;

			last = points.FindLastIndex(p => p.X < rightBound);

			if (last < points.Count - 1)
				last++;
			count = last - first;
			hasPoints = first >= 0 && last > 0;

			if (hasPoints) {
				startPoint = points[first];
			}
		}

		public Point StartPoint {
			get { return startPoint; }
		}

		public bool HasPoints {
			get { return hasPoints; }
		}

		#region IList<Point> Members

		public int IndexOf(Point item) {
			throw new NotSupportedException();
		}

		public void Insert(int index, Point item) {
			throw new NotSupportedException();
		}

		public void RemoveAt(int index) {
			throw new NotSupportedException();
		}

		public Point this[int index] {
			get {
				return points[first + 1 + index];
			}
			set {
				throw new NotSupportedException();
			}
		}

		#endregion

		#region ICollection<Point> Members

		public void Add(Point item) {
			throw new NotSupportedException();
		}

		public void Clear() {
			throw new NotSupportedException();
		}

		public bool Contains(Point item) {
			throw new NotSupportedException();
		}

		public void CopyTo(Point[] array, int arrayIndex) {
			throw new NotSupportedException();
		}

		public int Count {
			get { return count; }
		}

		public bool IsReadOnly {
			get { throw new NotSupportedException(); }
		}

		public bool Remove(Point item) {
			throw new NotSupportedException();
		}

		#endregion

		#region IEnumerable<Point> Members

		public IEnumerator<Point> GetEnumerator() {
			for (int i = first + 1; i <= last; i++) {
				yield return points[i];
			}
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion
	}
}
