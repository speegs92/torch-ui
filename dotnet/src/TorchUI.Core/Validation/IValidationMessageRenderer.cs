using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;

namespace TorchUI.Validation;

/// <summary>
/// Manages rnedering form field validation messages
/// </summary>
public interface IValidationMessageRenderer
{
	/// <summary>
	/// Renders a form field's validation messages
	/// </summary>
	/// <param name="builder">The render tree builder</param>
	/// <param name="validationErrors">The validation errors for the form field</param>
	void Render(
		RenderTreeBuilder builder,
		IEnumerable<string> validationErrors);
}
