using System;

namespace TorchUI.Bootstrap;

/// <summary>
/// The available column sizes in Bootstrap
/// </summary>
public readonly struct ColumnSize : IEquatable<ColumnSize>
{
	/// <summary>
	/// The size of the column as a number
	/// </summary>
	public readonly int Size;

	/// <summary>
	/// Whether the column is automatically sized (i.e., <c>.col-auto</c>)
	/// </summary>
	public readonly bool IsAuto;

	/// <summary>
	/// Whether the column is equally sized (i.e., <c>.col</c>)
	/// </summary>
	public readonly bool IsCol;

	private ColumnSize(
		int size,
		bool isAuto,
		bool isCol)
	{
		if (size == 0 && !isAuto && !isCol)
		{
			throw new ArgumentException($"If the provided {nameof(size)} is 0, you must set either {nameof(isAuto)} or {nameof(isCol)} to 'true'");
		}

		if (!isAuto && !isCol && size is > 12 or < 1)
		{
			throw new ArgumentOutOfRangeException(
				nameof(size),
				$"Bootstrap Grid supports between 1 and 12 columns, {size} provided");
		}

		Size = size;
		IsAuto = isAuto;
		IsCol = isCol;
	}

	/// <summary>
	/// A Bootstrap <c>.col{-breakpoint}-auto</c>
	/// </summary>
	public static readonly ColumnSize Auto = new(0, true, false);

	/// <summary>
	/// A Bootstrap <c>.col{-breakpoint}</c>
	/// </summary>
	public static readonly ColumnSize Col = new(0, false, true);

	/// <summary>
	/// A Bootstrap <c>.col{-breakpoint}-{size}</c>
	/// </summary>
	/// <param name="size">The size of the <c>ColumnSize</c></param>
	/// <returns>The new <c>ColumnSize</c></returns>
	public static implicit operator ColumnSize(int size) => new(size, false, false);

	/// <summary>
	/// A Bootstrap <c>.col{-breakpoint}-auto</c> or <c>.col{-breakpoint}</c>
	/// </summary>
	/// <remarks>
	/// If the provided cast value is not either <c>auto</c> or <c>col</c>, the <c>ColumnSize</c> constructor will throw an <see cref="ArgumentException"/>.
	/// </remarks>
	/// <param name="input">The string to convert to a <c>ColumnSize</c>. Must be one of <c>auto</c> or <c>col</c></param>
	/// <returns>The new <c>ColumnSize</c></returns>
	public static implicit operator ColumnSize(string input) => new(0, input == "auto", input == "col");

#region Equality

	public static bool operator ==(ColumnSize left, ColumnSize right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ColumnSize left, ColumnSize right)
	{
		return !(left == right);
	}

	/// <inheritdoc />
	public bool Equals(ColumnSize other)
	{
		return Size == other.Size &&
			IsAuto == other.IsAuto
			&& IsCol == other.IsCol;
	}

	/// <inheritdoc />
	public override bool Equals(object? obj)
	{
		return obj is ColumnSize other &&
			Equals(other);
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return HashCode.Combine(Size, IsAuto, IsCol);
	}

#endregion

}
