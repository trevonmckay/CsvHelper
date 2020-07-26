// Copyright 2009-2020 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;

namespace FileHelper.Configuration
{
	/// <summary>
	/// Configuration used for the <see cref="IReader"/>.
	/// </summary>
	public interface ICsvReaderConfiguration : IReaderConfiguration, IParserConfiguration
	{
		/// <summary>
		/// Gets or sets a value indicating if the
		/// CSV file has a header record.
		/// Default is true.
		/// </summary>
		bool HasHeaderRecord { get; set; }

		/// <summary>
		/// Gets or sets the function that is called when a header validation check is ran. The default function
		/// will throw a <see cref="ValidationException"/> if there is no header for a given member mapping.
		/// You can supply your own function to do other things like logging the issue instead of throwing an exception.
		/// Arguments: isValid, headerNames, headerNameIndex, context
		/// </summary>
		Action<bool, string[], int, ReadingContext> HeaderValidated { get; set; }

		/// <summary>
		/// Prepares the header field for matching against a member name.
		/// The header field and the member name are both ran through this function.
		/// You should do things like trimming, removing whitespace, removing underscores,
		/// and making casing changes to ignore case.
		/// </summary>
		Func<string, int, string> PrepareHeaderForMatch { get; set; }

		/// <summary>
		/// Gets or sets a callback that will return the prefix for a reference header.
		/// Arguments: memberType, memberName
		/// </summary>
		Func<Type, string, string> ReferenceHeaderPrefix { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether changes in the column
		/// count should be detected. If true, a <see cref="BadDataException"/>
		/// will be thrown if a different column count is detected.
		/// </summary>
		/// <value>
		/// <c>true</c> if [detect column count changes]; otherwise, <c>false</c>.
		/// </value>
		bool DetectColumnCountChanges { get; set; }
	}
}
