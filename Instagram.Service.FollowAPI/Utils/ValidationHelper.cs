using System.ComponentModel.DataAnnotations;

namespace Instagram.Services.FollowAPI.Utils {
    public static class ValidationHelper {
        public static List<ValidationResult> Validate(object model) {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);

            if (model is IValidatableObject validatableObject) {
                var additionalResults = validatableObject.Validate(validationContext);
                validationResults.AddRange(additionalResults);
            }

            return validationResults;
        }
    }
}
