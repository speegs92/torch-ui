using System;

namespace TorchUI.Bootstrap;

/// <summary>
/// The available auto-column sizes in Bootstrap
/// </summary>
public readonly struct AutoColumnSize : IEquatable<AutoColumnSize>
{
	/// <summary>
	/// The size of the auto-column as a number
	/// </summary>
	public readonly int Size;

	/// <summary>
	/// Whether the column is automatically sized (i.e., <c>.row-cols-auto</c>
	/// </summary>
	public readonly bool IsAuto;

	private AutoColumnSize(int size, bool isAuto)
	{
		if (size == 0 && !isAuto)
		{
			throw new ArgumentException($"If the provided {nameof(size)} is 0, you must set {nameof(isAuto)} to 'true'");
		}

		if (!isAuto && size is > 6 or < 1)
		{
			throw new ArgumentOutOfRangeException(
				nameof(size),
				$"Bootstrap Grid supports between 1 and 6 auto-columns, {size} provided");
		}

		Size = size;
		IsAuto = isAuto;
	}

	/// <summary>
	/// A Bootstrap <c>.row-cols{-breakpoint}-auto</c>
	/// </summary>
	public static readonly AutoColumnSize Auto = new(0, true);

	/// <summary>
	/// A Bootstrap <c>.col{-breakpoint}-{size}</c>
	/// </summary>
	/// <param name="size">The size of the <c>AutoColumnSize</c></param>
	/// <returns>The new <c>AutoColumnSize</c></returns>
	public static implicit operator AutoColumnSize(int size) => new(size, false);

	/// <summary>
	/// A Bootstrap <c>.col{-breakpoint}-auto</c>
	/// </summary>
	/// <remarks>
	/// If the provided cast value is not <c>auto</c>, the <c>AutoColumnSize</c> constructor will throw an <see cref="ArgumentException"/>.
	/// </remarks>
	/// <param name="input">The string to convert to an <c>AutoColumnSize</c>. Must be <c>auto</c></param>
	/// <returns>The new <c>AutoColumnSize</c></returns>
	public static implicit operator AutoColumnSize(string input) => new(0, input == "auto");

#region Equality

	public static bool operator ==(AutoColumnSize left, AutoColumnSize right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(AutoColumnSize left, AutoColumnSize right)
	{
		return !(left == right);
	}

	/// <inheritdoc />
	public bool Equals(AutoColumnSize other)
	{
		return Size == other.Size &&
			IsAuto == other.IsAuto;
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
		return HashCode.Combine(Size, IsAuto);
	}

#endregion

}
