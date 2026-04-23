using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using TorchUI.Validation;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Renders simple error messages in a Bootstrap-aligned manner
/// </summary>
public class BootstrapValidationMessageRenderer : IValidationMessageRenderer
{
	/// <inheritdoc />
	public void Render(
		RenderTreeBuilder builder,
		IEnumerable<string> validationErrors)
	{
		builder.OpenComponent<FormValidationErrorMessage>(0);
		builder.AddComponentParameter(1, nameof(FormValidationErrorMessage.Errors), validationErrors);
		builder.CloseComponent();
	}
}
