using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap number field
/// </summary>
public partial class FileField
{
	private Expression<Func<IFormFile?>>? _previousValueExpression;
	private string? _fieldName;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if (!ReferenceEquals(_previousValueExpression, ValueExpression))
		{
			_previousValueExpression = ValueExpression;

			if (ValueExpression is not null)
			{
				RegenerateFieldName();
			}
		}
	}

	void RegenerateFieldName()
	{
		var members = new List<string>();
		var node = ValueExpression?.Body;

		while (true)
		{
			if (node?.NodeType is not ExpressionType.MemberAccess)
			{
				break;
			}

			var memberExpression = (MemberExpression)node;

			members.Add(memberExpression.Member.Name);
			node = memberExpression.Expression;
		}

		members.Reverse();
		_fieldName = string.Join('.', members);
	}
}
