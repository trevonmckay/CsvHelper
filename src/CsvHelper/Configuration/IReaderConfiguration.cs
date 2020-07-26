﻿// Copyright 2009-2020 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Globalization;
using FileHelper.TypeConversion;
using System.Reflection;

namespace FileHelper.Configuration
{
	/// <summary>
	/// Configuration used for the <see cref="IReader"/>.
	/// </summary>
	public interface IReaderConfiguration : IParserConfiguration
	{
		/// <summary>
		/// Gets or sets the function that is called when a missing field is found. The default function will
		/// throw a <see cref="MissingFieldException"/>. You can supply your own function to do other things
		/// like logging the issue instead of throwing an exception.
		/// Arguments: headerNames, index, context
		/// </summary>
		Action<string[], int, ReadingContext> MissingFieldFound { get; set; }

		/// <summary>
		/// Gets or sets the function that is called when a reading exception occurs.
		/// The default function will re-throw the given exception. If you want to ignore
		/// reading exceptions, you can supply your own function to do other things like
		/// logging the issue.
		/// Arguments: exception
		/// </summary>
		Func<CsvHelperException, bool> ReadingExceptionOccurred { get; set; }

		/// <summary>
		/// Gets or sets the culture info used to read an write CSV files.
		/// </summary>
		CultureInfo CultureInfo { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="TypeConverterOptionsCache"/>.
		/// </summary>
		TypeConverterOptionsCache TypeConverterOptionsCache { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="TypeConverterCache"/>.
		/// </summary>
		TypeConverterCache TypeConverterCache { get; set; }

		/// <summary>
		/// Determines if constructor parameters should be used to create
		/// the class instead of the default constructor and members.
		/// </summary>
		Func<Type, bool> ShouldUseConstructorParameters { get; set; }

		/// <summary>
		/// Chooses the constructor to use for constructor mapping.
		/// </summary>
		Func<Type, ConstructorInfo> GetConstructor { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether references
		/// should be ignored when auto mapping. True to ignore
		/// references, otherwise false. Default is false.
		/// </summary>
		bool IgnoreReferences { get; set; }

		/// <summary>
		/// Gets or sets the callback that will be called to
		/// determine whether to skip the given record or not.
		/// </summary>
		Func<string[], bool> ShouldSkipRecord { get; set; }

		/// <summary>
		/// Gets or sets a value indicating if private
		/// member should be read from and written to.
		/// True to include private member, otherwise false. Default is false.
		/// </summary>
		bool IncludePrivateMembers { get; set; }

		/// <summary>
		/// Gets or sets the member types that are used when auto mapping.
		/// MemberTypes are flags, so you can choose more than one.
		/// Default is Properties.
		/// </summary>
		MemberTypes MemberTypes { get; set; }

		/// <summary>
		/// The configured <see cref="ClassMap"/>s.
		/// </summary>
		ClassMapCollection Maps { get; }

		/// <summary>
		/// Use a <see cref="ClassMap{T}" /> to configure mappings.
		/// When using a class map, no members are mapped by default.
		/// Only member specified in the mapping are used.
		/// </summary>
		/// <typeparam name="TMap">The type of mapping class to use.</typeparam>
		TMap RegisterClassMap<TMap>() where TMap : ClassMap;

		/// <summary>
		/// Use a <see cref="ClassMap{T}" /> to configure mappings.
		/// When using a class map, no member are mapped by default.
		/// Only member specified in the mapping are used.
		/// </summary>
		/// <param name="classMapType">The type of mapping class to use.</param>
		ClassMap RegisterClassMap( Type classMapType );

	    /// <summary>
	    /// Registers the class map.
	    /// </summary>
	    /// <param name="map">The class map to register.</param>
	    void RegisterClassMap( ClassMap map );

	    /// <summary>
	    /// Unregisters the class map.
	    /// </summary>
	    /// <typeparam name="TMap">The map type to unregister.</typeparam>
	    void UnregisterClassMap<TMap>() where TMap : ClassMap;

	    /// <summary>
	    /// Unregisters the class map.
	    /// </summary>
	    /// <param name="classMapType">The map type to unregister.</param>
	    void UnregisterClassMap( Type classMapType );

	    /// <summary>
	    /// Unregisters all class maps.
	    /// </summary>
	    void UnregisterClassMap();

		/// <summary>
		/// Generates a <see cref="ClassMap"/> for the type.
		/// </summary>
		/// <typeparam name="T">The type to generate the map for.</typeparam>
		/// <returns>The generate map.</returns>
		ClassMap<T> AutoMap<T>();

	    /// <summary>
	    /// Generates a <see cref="ClassMap"/> for the type.
	    /// </summary>
	    /// <param name="type">The type to generate for the map.</param>
	    /// <returns>The generate map.</returns>
	    ClassMap AutoMap( Type type );
	}
}
