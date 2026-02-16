using TorchUI.Validation;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Contains TorchUI extension methods for <see langword="IServiceCollection"/>
/// </summary>
public static class TorchUIServiceCollectionExtensions
{
	public static IServiceCollection AddTorchUI(this IServiceCollection self)
	{
		self
			.AddScoped<IValidationAttributeGenerator, DefaultValidationAttributeGenerator>();

		return self;
	}
}
