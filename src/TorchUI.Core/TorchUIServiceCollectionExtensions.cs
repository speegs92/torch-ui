using System.ComponentModel.DataAnnotations;
using TorchUI.Forms;
using TorchUI.Validation;
using TorchUI.Validation.Mappers;

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
			.AddScoped<IFieldNameGenerator, DefaultFieldNameGenerator>()
			.AddScoped<IValidationAttributeGenerator, DefaultValidationAttributeGenerator>()
			.AddScoped<IValidationRuleMapper<RequiredAttribute>, RequiredAttributeMapper>()
			.AddScoped<IValidationRuleMapper<MinLengthAttribute>, MinLengthAttributeMapper>();

		return self;
	}
}
