using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using TorchUI.Forms;

// ReSharper disable once CheckNamespace
namespace TorchUI;

/// <summary>
/// Renders a group of checkboxes
/// </summary>
public partial class InputCheckboxGroup<TValue> : ComponentBase
{
	private Expression<Func<IEnumerable<TValue>?>>? _previousValueExpression;
	private CheckboxGroupContext<TValue>? _context;

	/// <summary>
	/// The value of the checkbox group
	/// </summary>
	[Parameter]
	public IEnumerable<TValue>? Value { get; set; }

	/// <summary>
	/// A callback to update the value of the checkbox group
	/// </summary>
	[Parameter]
	public EventCallback<IEnumerable<TValue>?> ValueChanged { get; set; }

	/// <summary>
	/// An expression identifying the model member bound to the checkbox group
	/// </summary>
	[Parameter]
	public Expression<Func<IEnumerable<TValue>?>>? ValueExpression { get; set; }

	/// <summary>
	/// The child content to render
	/// </summary>
	[Parameter]
	[EditorRequired]
	public RenderFragment ChildContent { get; set; }

	[Inject]
	private IFieldNameGenerator FieldNameGenerator { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if (!ReferenceEquals(_previousValueExpression, ValueExpression))
		{
			_previousValueExpression = ValueExpression;
			_context = new()
			{
				Name = FieldNameGenerator.Generate(ValueExpression),
				Selected = Value
			};
		}
	}
}

