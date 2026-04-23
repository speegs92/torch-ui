using System.Collections.Generic;
using Microsoft.AspNetCore.Components; 

// Resharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Renders errors for a form field
/// </summary>
public partial class FormValidationErrorMessage
{
	/// <summary>
	/// The errors for the current form field
	/// </summary>
	[Parameter]
	public IEnumerable<string> Errors { get; set; } = [];

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("list-unstyled text-danger");
	}
}

