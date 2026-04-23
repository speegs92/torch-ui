using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

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

	/// <summary>
	/// The calculated ID of the input
	/// </summary>
	/// <remarks>
	/// If <see cref="InputId"/> is supplied, its value is returned. Otherwise, a fallback GUID-based ID is returned.
	/// </remarks>
	protected string Id => InputId ?? _fallbackId;

	/// <summary>
	/// The ID of the input
	/// </summary>
	[Parameter]
	public string? InputId { get; set; }

	[Parameter]
	public string? Label { get; set; }

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
}
