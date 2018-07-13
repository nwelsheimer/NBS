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
using System.Resources;
using System.Windows.Markup;
using System.Runtime.CompilerServices;
using Openmiracle.MiracleIChart;
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]

[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.Navigation")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.Charts.Navigation")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.Charts")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.DataSources")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.Common.Palettes")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.Charts.Axes")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.PointMarkers")]
[assembly: XmlnsDefinition(D3AssemblyConstants.DefaultXmlNamespace, "Openmiracle.MiracleIChart.Charts.Shapes")]

[assembly: XmlnsPrefix(D3AssemblyConstants.DefaultXmlNamespace, "StinoKJames")]

[assembly: CLSCompliant(true)]
[assembly: InternalsVisibleTo("MiracleIChart.Test, PublicKey=002400000480000094000000060200000024000052534131000400000100010039f88065585acdedaac491218a8836c4c54070b4b0f85bc909bd002856b509349f95fc845d1d4c664ea6b93045f2ada3b4fe70c6cd9b3fb615f94b8b5f67e4ea8ea5decb233e2e3c0ce84b78dc3ca0cd9fd2260792ece12224fca5813f03c7ad57b1faa07e3ca8fafb278fa23976fc7a35b8b4ae4efedacd1e193d89738ac2aa")]
[assembly: InternalsVisibleTo("MiracleIChart.Maps, PublicKey=002400000480000094000000060200000024000052534131000400000100010039f88065585acdedaac491218a8836c4c54070b4b0f85bc909bd002856b509349f95fc845d1d4c664ea6b93045f2ada3b4fe70c6cd9b3fb615f94b8b5f67e4ea8ea5decb233e2e3c0ce84b78dc3ca0cd9fd2260792ece12224fca5813f03c7ad57b1faa07e3ca8fafb278fa23976fc7a35b8b4ae4efedacd1e193d89738ac2aa")]

namespace Openmiracle.MiracleIChart
{
	public static class D3AssemblyConstants
	{
        public const string DefaultXmlNamespace = "http://openmiracle.com/MiracleIChart/1.0";
	}
}
