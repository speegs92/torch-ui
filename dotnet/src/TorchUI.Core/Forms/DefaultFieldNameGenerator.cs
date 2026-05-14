using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TorchUI.Forms;

/// <summary>
/// The default implementation of <see cref="IFieldNameGenerator"/>
/// </summary>
public class DefaultFieldNameGenerator : IFieldNameGenerator
{
	/// <inheritdoc />
	public string Generate<T>(Expression<Func<T>>? ex)
	{
		var members = new List<string>();
		var node = ex?.Body;

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
		return string.Join('.', members);
	}
}
