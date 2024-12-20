using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Handlers.Validations
{
    public static class ValidationsExtension
    {
        public static ModelStateDictionary ValidateRequired(this ModelStateDictionary modelState, string formField, string fieldName)
        {
            if (String.IsNullOrWhiteSpace(formField))
            {
                modelState.AddModelError(fieldName, $"Le champ '{fieldName}' est obligatoire.");
            }
            return modelState;
        }

        public static ModelStateDictionary ValidateLength(this ModelStateDictionary modelState, string formField, string fieldName, int minLength, int maxLength)
        {
            if (maxLength < minLength) throw new ArgumentException(nameof(maxLength));
            if (!(formField is null) && (formField.Length < minLength || formField.Length > maxLength)) {
                modelState.AddModelError(fieldName, $"Le champ '{fieldName}' doit avoir entre {minLength} et {maxLength} caractères.");
            }
            return modelState;
        }

        public static ModelStateDictionary ValidateNeedLowerCase(this ModelStateDictionary modelState, string formField, string fieldName)
        {
            if (!(formField is null) && !Regex.IsMatch(formField, @"[a-z]"))
            {
                modelState.AddModelError(fieldName, $"Le champs '{fieldName}' doit contenir au minimum une minuscule.");
            }
            return modelState;
        }
        public static ModelStateDictionary ValidateNeedUpperCase(this ModelStateDictionary modelState, string formField, string fieldName)
        {
            if (!(formField is null) && !Regex.IsMatch(formField, @"[A-Z]"))
            {
                modelState.AddModelError(fieldName, $"Le champs '{fieldName}' doit contenir au minimum une majuscule.");
            }
            return modelState;
        }
        public static ModelStateDictionary ValidateNeedNumber(this ModelStateDictionary modelState, string formField, string fieldName)
        {
            if (!(formField is null) && !Regex.IsMatch(formField, @"[0-9]"))
            {
                modelState.AddModelError(fieldName, $"Le champs '{fieldName}' doit contenir au minimum un chiffre.");
            }
            return modelState;
        }

        public static ModelStateDictionary ValidateNeedSymbol(this ModelStateDictionary modelState, string formField, string fieldName)
        {
            if (!(formField is null) && !Regex.IsMatch(formField, @"[&@#-+=*?!%~/\\<>]"))
            {
                modelState.AddModelError(fieldName, $"Le champs '{fieldName}' doit contenir au minimum un symbole.");
            }
            return modelState;
        }
    }
}
