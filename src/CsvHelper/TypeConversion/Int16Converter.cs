﻿// Copyright 2009-2020 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System.Globalization;
using FileHelper.Configuration;

namespace FileHelper.TypeConversion
{
	/// <summary>
	/// Converts a <see cref="short"/> to and from a <see cref="string"/>.
	/// </summary>
	public class Int16Converter : DefaultTypeConverter
	{
		/// <summary>
		/// Converts the string to an object.
		/// </summary>
		/// <param name="text">The string to convert to an object.</param>
		/// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
		/// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
		/// <returns>The object created from the string.</returns>
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			var numberStyle = memberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;

			if (short.TryParse(text, numberStyle, memberMapData.TypeConverterOptions.CultureInfo, out var s))
			{
				return s;
			}

			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
