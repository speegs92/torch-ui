using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using TorchUI.Validation;

// ReSharper disable once CheckNamespace
namespace TorchUI;

/// <summary>
/// Displays a list of validation messages for a specified field within a cascaded <see cref="EditContext"/>
/// </summary>
/// <remarks>
/// The source code was copied almost verbatim from <see cref="Microsoft.AspNetCore.Components.Forms.ValidationMessage{TValue}"/>. The only major change in functionality is the addition of <see cref="IValidationMessageRenderer"/>, which handles rendering error messages in a configurable way.
/// </remarks>
/// <typeparam name="TValue">The type of the form field value</typeparam>
public class FieldValidationMessage<TValue> : ComponentBase, IDisposable
{
	private EditContext? _previousEditContext;
	private Expression<Func<TValue?>>? _previousFieldAccessor;
	private readonly EventHandler<ValidationStateChangedEventArgs>? _validationStateChangedHandler;
	private FieldIdentifier _fieldIdentifier;

	[CascadingParameter]
	private EditContext CurrentEditContext { get; set; } = null!;

	/// <summary>
	/// Specifies the field for which validation messages should be displayed.
	/// </summary>
	[Parameter]
	public Expression<Func<TValue?>>? For { get; set; }

	[Inject]
	private IValidationMessageRenderer Renderer { get; set; } = null!;

	/// <summary>`
	/// Creates a new instance of <see cref="FieldValidationMessage{TValue}"/>.
	/// </summary>
	public FieldValidationMessage()
	{
		_validationStateChangedHandler = (_, _) => StateHasChanged();
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if (CurrentEditContext == null)
		{
			throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type {nameof(EditContext)}. For example, you can use {GetType()} inside an {nameof(EditForm)}.");
		}

		if (For == null) // Not possible except if you manually specify T
		{
			throw new InvalidOperationException($"{GetType()} requires a value for the {nameof(For)} parameter.");
		}

		if (For != _previousFieldAccessor)
		{			
			_fieldIdentifier = FieldIdentifier.Create(For);
			_previousFieldAccessor = For;
		}

		if (CurrentEditContext != _previousEditContext)
		{
			DetachValidationStateChangedListener();
			CurrentEditContext.OnValidationStateChanged += _validationStateChangedHandler;
			_previousEditContext = CurrentEditContext;
		}
	}

	/// <inheritdoc />
	protected override void BuildRenderTree(RenderTreeBuilder builder)
		=> Renderer.Render(
			builder,
			CurrentEditContext.GetValidationMessages(_fieldIdentifier));

	void IDisposable.Dispose()
	{
		DetachValidationStateChangedListener();
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing) {}

	private void DetachValidationStateChangedListener()
	{
		if (_previousEditContext != null)
		{
			_previousEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
		}
	}
}