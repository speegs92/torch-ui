using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.navbar-brand</c>
/// </summary>
public class NavbarBrand : TorchComponentBase
{
	/// <summary>
	/// The destination of the brand link, if any
	/// </summary>
	/// <remarks>
	/// If this parameter is provided, the <see cref="TorchComponentBase.Tag"/> value is coerced to <c>a</c>. Otherwise, the component doesn't explicitly set the tag.
	/// </remarks>
	[Parameter]
	public string? Href { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		if (!string.IsNullOrEmpty(Href))
		{
			Tag = "a";
			UserAttributes["href"] = Href;
		}

		CssBuilder.AddClass("navbar-brand");
	}
}
