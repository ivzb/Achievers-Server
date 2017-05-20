using Achiever.Common;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace Achiever.Web.Helpers.ModelBinders
{
    public class CustomNullDateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;

            if (valueResult == null || string.IsNullOrWhiteSpace(valueResult.AttemptedValue))
            {
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                return actualValue;
            }

            try
            {
                actualValue = Convert.ToDateTime(valueResult.AttemptedValue,
                    new CultureInfo(Settings.DateTimeCulture));
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}