using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.col</c>
/// </summary>
public class Col : TorchComponentBase
{

#region Columns

	/// <summary>
	/// The width of this column on the default breakpoint
	/// </summary>
	[Parameter]
	public ColumnSize? Xs { get; set; } = ColumnSize.Col;

	/// <summary>
	/// The width of this column on the small breakpoint
	/// </summary>
	[Parameter]
	public ColumnSize? Sm { get; set; }

	/// <summary>
	/// The width of this column on the medium breakpoint
	/// </summary>
	[Parameter]
	public ColumnSize? Md { get; set; }

	/// <summary>
	/// The width of this column on the large breakpoint
	/// </summary>
	[Parameter]
	public ColumnSize? Lg { get; set; }

	/// <summary>
	/// The width of this column on the extra-large breakpoint
	/// </summary>
	[Parameter]
	public ColumnSize? Xl { get; set; }

	/// <summary>
	/// The width of this column on the extra-extra-large breakpoint
	/// </summary>
	[Parameter]
	public ColumnSize? Xxl { get; set; }

	private void AddBreakpointCols(string? infix, ColumnSize? columnSize)
	{
		if (columnSize is null)
		{
			return;
		}

		var size = columnSize.Value;

		var className = string.IsNullOrEmpty(infix)
			? "col"
			: $"col-{infix}";

		if (size.IsAuto)
		{
			className = $"{className}-auto";
		}
		else if (!size.IsCol)
		{
			className = $"{className}-{size.Size}";
		}

		CssBuilder.AddClass(className);
	}

#endregion

#region Offsets

	/// <summary>
	/// The offset of this column on the default breakpoint
	/// </summary>
	[Parameter]
	public int? XsOffset { get; set; }

	/// <summary>
	/// The offset of this column on the small breakpoint
	/// </summary>
	[Parameter]
	public int? SmOffset { get; set; }

	/// <summary>
	/// The offset of this column on the medium breakpoint
	/// </summary>
	[Parameter]
	public int? MdOffset { get; set; }

	/// <summary>
	/// The offset of this column on the large breakpoint
	/// </summary>
	[Parameter]
	public int? LgOffset { get; set; }

	/// <summary>
	/// The offset of this column on the extra-large breakpoint
	/// </summary>
	[Parameter]
	public int? XlOffset { get; set; }

	/// <summary>
	/// The offset of this column on the extra-extra-large breakpoint
	/// </summary>
	[Parameter]
	public int? XxlOffset { get; set; }

	private void AddBreakpointOffsets(string? infix, int? offset)
	{
		if (offset is null)
		{
			return;
		}

		if (offset is >11 or <1)
		{
			throw new ArgumentOutOfRangeException(
				nameof(offset),
				$"Bootstrap Grid supports column offsets of 1-11, {offset} provided");
		}

		var className = string.IsNullOrEmpty(infix)
			? $"offset-{offset}"
			: $"offset-{infix}-{offset}";

		CssBuilder.AddClass(className);
	}

#endregion

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		AddBreakpointCols(null, Xs);
		AddBreakpointCols("sm", Sm);
		AddBreakpointCols("md", Md);
		AddBreakpointCols("lg", Lg);
		AddBreakpointCols("xl", Xl);
		AddBreakpointCols("xxl", Xxl);

		AddBreakpointOffsets(null, XsOffset);
		AddBreakpointOffsets("sm", SmOffset);
		AddBreakpointOffsets("md", MdOffset);
		AddBreakpointOffsets("lg", LgOffset);
		AddBreakpointOffsets("xl", XlOffset);
		AddBreakpointOffsets("xxl", XxlOffset);
	}
}
