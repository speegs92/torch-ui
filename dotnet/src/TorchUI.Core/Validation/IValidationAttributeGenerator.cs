using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TorchUI.Validation;

/// <summary>
/// An interface for generating HTML attributes to translate .NET validation rules into <c>data-*</c> attributes for use by JavaScript on the client
/// </summary>
public interface IValidationAttributeGenerator
{
	/// <summary>
	/// Generates attributes for the given expression 
	/// </summary>
	/// <param name="valueExpression">An expression representing the model member for which to generate validation attributes</param>
	/// <typeparam name="TValue">The type of the model member for which to generate validation attributes</typeparam>
	/// <returns>A dictionary of validation attributes</returns>
	Dictionary<string, object> Generate<TValue>(Expression<Func<TValue>> valueExpression);
}
