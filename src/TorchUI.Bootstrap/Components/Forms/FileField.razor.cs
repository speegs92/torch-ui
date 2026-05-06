using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using TorchUI.Forms;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap number field
/// </summary>
public partial class FileField
{
	private Expression<Func<IFormFile?>>? _previousValueExpression;
	private string? _fieldName;

	[Inject]
	private IFieldNameGenerator FieldNameGenerator { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if (!ReferenceEquals(_previousValueExpression, ValueExpression))
		{
			_previousValueExpression = ValueExpression;
			_fieldName = FieldNameGenerator.Generate(ValueExpression);
		}

		base.OnParametersSet();
	}
}
