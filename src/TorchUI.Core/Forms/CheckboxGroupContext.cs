using System.Collections.Generic;

namespace TorchUI.Forms;

/// <summary>
/// The context communicating the checkbox group's state to child components
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public class CheckboxGroupContext<TValue>
{
	/// <summary>
	/// The name of the checkbox group
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// The selected items
	/// </summary>
	public IEnumerable<TValue>? Selected { get; set; }
}
