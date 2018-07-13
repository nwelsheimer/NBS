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
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	public static class ListGenerator {
		public static IEnumerable<Point> GeneratePoints(int length, Func<int, Point> generator) {
			for (int i = 0; i < length; i++) {
				yield return generator(i);
			}
		}

		public static IEnumerable<Point> GeneratePoints(int length, Func<int, double> x, Func<int, double> y) {
			for (int i = 0; i < length; i++) {
				yield return new Point(x(i), y(i));
			}
		}

		public static IEnumerable<T> Generate<T>(int length, Func<int, T> generator) {
			for (int i = 0; i < length; i++) {
				yield return generator(i);
			}
		}
	}
}
