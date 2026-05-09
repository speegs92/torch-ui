export function initializeForms(): void {
	for (let form of document.getElementsByTagName('form')) {
		initializeForm(form);
	}
}

export function initializeForm(form: HTMLFormElement): void {
	
}

/**
 * A function which validates the state of a form field
 */
export interface FormFieldValidator {
	(): boolean;
}

/**
 * Represents a form field
 */
export interface FormField<T> {
	/**
	 * The display name of the form field, used for error validation purposes
	 */
	displayName: string|null|undefined;

	/**
	 * The function which validates the value of a form field
	 */
	validator: FormFieldValidator;

	/**
	 * The current value of the form field
	 */
	value: T|null|undefined;

	/**
	 * An array of validation results
	 */
	validationResults: ValidationResult[];
}

/**
 * A validation result for form field validation
 */
export type ValidationResult = {
	/**
	 * Whether the form field value is valid
	 */
	valid: boolean|null;

	/**
	 * The validation message to show the user
	 */
	message: string;
}

/**
 * An object representing a form value validation rule
 */
export interface FormValueValidator<T> {
	/**
	 * The message to display to the user on a validation error
	 */
	message: string;

	/**
	 * A function used to determine whether the value passes validation
	 * 
	 * @param input The form input value
	 * @returns whether the value is valid
	 */
	isValid(input: T|null|undefined): boolean;

	replacementValues?: Record<string, ((values: Record<string, FormField<T>>) => string)|string|number>;
}
