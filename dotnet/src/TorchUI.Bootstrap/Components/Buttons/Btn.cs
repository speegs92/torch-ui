// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.btn</c>
/// </summary>
/// <remarks>
/// Because Bootstrap button classes are valid on different types of markup, this component attempts to infer which type of markup should be rendered based on the supplied attributes. If an <c>href</c> is supplied, the component renders as an <c>&lt;a&gt;</c> tag. If a <c>value</c> is supplied, the component renders as an <c>&lt;input type="button"&gt;</c>. If neither value is supplied, the component renders as a <c>&lt;button&gt;</c>.
/// </remarks>
public class Btn : BtnBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		if (UserAttributes.ContainsKey("href"))
		{
			// If there's an href, this should be a link
			Tag = "a";
		}
		else if (UserAttributes.ContainsKey("value"))
		{
			Tag = "input";
		}

		base.SetupAttributes();
	}
}