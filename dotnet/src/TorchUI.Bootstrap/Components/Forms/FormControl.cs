using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.form-control</c>
/// </summary>
/// <typeparam name="TValue"></typeparam>
public abstract class FormControl<TValue> : BaseField<TValue>
{
	protected string? FormControlClasses =>
		new CssBuilder()
			.AddClass("form-control")
			.AddClass(Size.GetSizeClass("form-control"), Size is not Size.Medium)
			.Build();

	/// <summary>
	/// The form control's size
	/// </summary>
	[Parameter]
	public Size Size { get; set; } = Size.Medium;
}
