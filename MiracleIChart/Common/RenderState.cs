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

using System.Windows;

namespace Openmiracle.MiracleIChart
{
	/// <summary>
	/// Target of rendering
	/// </summary>
	public enum RenderTo
	{
		/// <summary>
		/// Rendering directly to screen
		/// </summary>
		Screen,
		/// <summary>
		/// Rendering to bitmap, which will be drawn to screen later.
		/// </summary>
		Image
	}

	public sealed class RenderState
	{
		private readonly Rect visible;

		private readonly Rect output;


		private readonly Rect renderVisible;

		private readonly RenderTo renderingType;

		public Rect RenderVisible
		{
			get { return renderVisible; }
		}

		public RenderTo RenderingType
		{
			get { return renderingType; }
		}

		public Rect Output
		{
			get { return output; }
		}

		public Rect Visible
		{
			get { return visible; }
		}

		public RenderState(Rect renderVisible, Rect visible, Rect output, RenderTo renderingType)
		{
			this.renderVisible = renderVisible;
			this.visible = visible;
			this.output = output;
			this.renderingType = renderingType;
		}
	}
}
