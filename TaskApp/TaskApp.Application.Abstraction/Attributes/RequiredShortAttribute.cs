using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using TaskApp.Dictionaries;
using TaskApp.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.Application
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredShortAttribute : RequiredAttribute, IClientModelValidator
    {
        public RequiredShortAttribute() : base()
        {
            ErrorMessageResourceType = typeof(ErrorResource);
            ErrorMessageResourceName = "RequiredShort";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val-required", FormatErrorMessage(""));
        }

        bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}
