using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using TorchUI.Validation.Mappers;

namespace TorchUI.Validation;

/// <summary>
/// A default implementation of <see cref="IValidationAttributeGenerator"/>
/// </summary>
public class DefaultValidationAttributeGenerator : IValidationAttributeGenerator
{
	private readonly IServiceProvider _sp;

	/// <summary>
	/// Creates a new instance of <c>DefaultValidationAttributeGenerator</c>
	/// </summary>
	/// <param name="sp">The service provider for the current scope</param>
	public DefaultValidationAttributeGenerator(
		IServiceProvider sp)
	{
		_sp = sp;
	}

	/// <inheritdoc />
	public Dictionary<string, object> Generate<TValue>(Expression<Func<TValue>> valueExpression)
	{
		var htmlAttributes = new Dictionary<string, object>();

		var propertyInfo = GetPropertyInfo(valueExpression);

		if (propertyInfo is null)
		{
			return htmlAttributes;
		}

		var hasValidations = false;
		var validationAttributes = propertyInfo.GetCustomAttributes<ValidationAttribute>(true);

		foreach (var a in validationAttributes)
		{
			var mapper = (IValidationRuleMapper?) _sp.GetService(typeof(IValidationRuleMapper<>).MakeGenericType(a.GetType()));

			if (mapper is not null)
			{
				mapper.MapToHtmlAttributes(a, htmlAttributes);
				hasValidations = true;
			}
		}

		if (hasValidations)
		{
			htmlAttributes["data-validate"] = true;
		}

		return htmlAttributes;
	}

	private static PropertyInfo? GetPropertyInfo<TValue>(Expression<Func<TValue>> valueExpression)
	{
		if (valueExpression.Body is MemberExpression memberExpression)
		{
			return memberExpression.Member as PropertyInfo;
		}

		if (valueExpression.Body is UnaryExpression { Operand: MemberExpression unaryMemberExpression })
		{
			return unaryMemberExpression.Member as PropertyInfo;
		}

		return null;
	}

	
}
