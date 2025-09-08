using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels.Base
{
    public abstract partial class BaseFormModel : ObservableValidator
    {
        public bool Validate()
        {
            ClearErrors();
            ValidateAllProperties();

            return !HasErrors;
        }

        public string? GetError(string propertyName)
        {
            var errors = GetErrors(propertyName);
            return errors?.OfType<ValidationResult>().FirstOrDefault()?.ErrorMessage;
        }

        protected void WireErrors(params (string? Property, Action<string?> SetError)[] map)
        {
            ErrorsChanged += (_, e) =>
            {
                foreach (var (prop, setter) in map.Where(m =>
                         string.IsNullOrEmpty(e.PropertyName) || m.Property == e.PropertyName))
                {
                    setter(GetError(prop));
                }
            };
        }
    }
}
