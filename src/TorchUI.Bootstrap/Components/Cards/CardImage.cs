using System;
using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap .card-img
/// </summary>
public class CardImage : TorchComponentBase
{
	private Placement? _placement;

#pragma warning disable BL0007 // Component parameter should be auto property

	/// <summary>
	/// The position of the image
	/// </summary>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown when the value provided is not <see cref="Placement.Top"/> or <see cref="Placement.Bottom"/>
	/// </exception>
	[Parameter]
	public Placement? Placement
	{
		get => _placement;
		set
		{
			if (value is null)
			{
				_placement = value;
				return;
			}

			if (value.Value is not (Bootstrap.Placement.Top or Bootstrap.Placement.Bottom))
			{
				throw new ArgumentOutOfRangeException($"The {nameof(CardImage)} component only supports {Bootstrap.Placement.Top} and {Bootstrap.Placement.Bottom} positions");
			}

			_placement = value;
		}
	}

#pragma warning restore BL0007

	public CardImage()
	{
		Tag = "img";
	}

	protected override void SetupAttributes()
	{
		if (_placement is not null)
		{
			CssBuilder.AddClass(_placement.Value.GetPlacementClass("card-img"));
		}
		else
		{
			CssBuilder.AddClass("card-img");
		}
	}
}
