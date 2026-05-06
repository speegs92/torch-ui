using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using TorchUI.Validation;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap base field 
/// </summary>
/// <typeparam name="TValue">The type of the input value</typeparam>
public class BaseField<TValue> : TorchComponentBase
{
	private readonly string _fallbackId = Guid
		.NewGuid()
		.ToString();

	private Dictionary<string, object> _validationAttributes = new();
	private Expression<Func<TValue>>? _previousValueExpression;

	/// <summary>
	/// The calculated ID of the input
	/// </summary>
	/// <remarks>
	/// If <see cref="InputId"/> is supplied, its value is returned. Otherwise, a fallback GUID-based ID is returned.
	/// </remarks>
	protected string Id => InputId ?? _fallbackId;

	/// <summary>
	/// The calculated ID of the form description text
	/// </summary>
	protected string FormTextId => $"{Id}-form-text";

	/// <summary>
	/// The ID of the input
	/// </summary>
	[Parameter]
	public string? InputId { get; set; }

	/// <summary>
	/// The label text, if any
	/// </summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>
	/// The form helper text to display, if any
	/// </summary>
	[Parameter]
	public string? FormText { get; set; }

	/// <summary>
	/// The value of the form field
	/// </summary>
	[Parameter]
	public TValue? Value { get; set; }

	/// <summary>
	/// A callback to update the value of the form field
	/// </summary>
	[Parameter]
	public EventCallback<TValue> ValueChanged { get; set; }

	/// <summary>
	/// An expression identifying the model member bound to the field
	/// </summary>
	[Parameter]
	public Expression<Func<TValue>>? ValueExpression { get; set; }

	[Inject]
	private IValidationAttributeGenerator ValidationAttributeGenerator { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if (!ReferenceEquals(_previousValueExpression, ValueExpression))
		{
			_previousValueExpression = ValueExpression;

			if (ValueExpression is not null)
			{
				_validationAttributes = ValidationAttributeGenerator.Generate(ValueExpression);
			}

			foreach (var attr in _validationAttributes)
			{
				UserAttributes.Add(attr.Key, attr.Value);
			}
		}

		base.OnParametersSet();
	}
}
