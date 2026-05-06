// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents an <c>&lt;a class="list-group-item"&gt;</c>
/// </summary>
public class ListGroupItemLink : ListGroupItemBase
{
	/// <summary>
	/// Creates a new instance of <c>ListGroupItemLink</c>
	/// </summary>
	public ListGroupItemLink() => Tag = "a";
}
