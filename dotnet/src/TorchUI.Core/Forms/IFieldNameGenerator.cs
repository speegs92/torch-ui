using System;
using System.Linq.Expressions;

namespace TorchUI.Forms;

/// <summary>
/// Generates a form input's field name
/// </summary>
public interface IFieldNameGenerator
{
	/// <summary>
	/// Generates a form input's field name
	/// </summary>
	/// <param name="ex">An expression signifying the form input's model field</param>
	/// <returns>The form input's field name</returns>
	string Generate<T>(Expression<Func<T>>? ex);
}
