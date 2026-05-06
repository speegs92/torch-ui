using TorchUI.Bootstrap.Components;
using TorchUI.Validation;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Contains TorchUI Bootstrap extension methods for <see cref="IServiceCollection"/>
/// </summary>
public static class TorchUIBootstrapServiceCollectionExtensions
{
	/// <summary>
	/// Adds services required by <c>TorchUI.Bootstrap</c>
	/// </summary>
	/// <param name="self">The service collection</param>
	/// <returns>The service collection</returns>
	public static IServiceCollection AddTorchUIBootstrap(
		this IServiceCollection self)
	{
		self.TryAddScoped<IValidationMessageRenderer, BootstrapValidationMessageRenderer>();

		return self;
	}
}
