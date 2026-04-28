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
			.AddScoped<IValidationRuleMapper<MinLengthAttribute>, MinLengthAttributeMapper>()
			.AddScoped<IValidationRuleMapper<MaxLengthAttribute>, MaxLengthAttributeMapper>()
			.AddScoped<IValidationRuleMapper<StringLengthAttribute>, StringLengthAttributeMapper>()
			.AddScoped<IValidationRuleMapper<RangeAttribute>, RangeAttributeMapper>()
			.AddScoped<IValidationRuleMapper<RegularExpressionAttribute>, RegularExpressionAttributeMapper>()
			.AddScoped<IValidationRuleMapper<EmailAddressAttribute>, EmailAddressAttributeMapper>()
			.AddScoped<IValidationRuleMapper<PhoneAttribute>, PhoneAttributeMapper>()
			.AddScoped<IValidationRuleMapper<UrlAttribute>, UrlAttributeMapper>()
			.AddScoped<IValidationRuleMapper<CreditCardAttribute>, CreditCardAttributeMapper>()
			.AddScoped<IValidationRuleMapper<CompareAttribute>, CompareAttributeMapper>();

		return self;
	}
}
