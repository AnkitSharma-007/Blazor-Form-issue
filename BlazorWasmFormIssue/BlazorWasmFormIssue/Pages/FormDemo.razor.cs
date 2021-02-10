using BlazorCourseDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace BlazorWasmFormIssue.Pages
{
    public class FormDemoBase : ComponentBase
    {
        protected User editContextuser = new();
        protected EditContext editFormContext;
        protected bool isFormInvalid = true;
        protected string showValidationSummary = "display:none";


        protected override Task OnInitializedAsync()
        {
            editFormContext = new EditContext(editContextuser);
            editFormContext.OnFieldChanged += HandleFormFieldChangedEvent;
            return base.OnInitializedAsync();
        }

        protected void HandleFormFieldChangedEvent(object sender, FieldChangedEventArgs e)
        {
            isFormInvalid = !editFormContext.Validate();
            StateHasChanged();
        }

        protected void HandleEditContextFormSubmit()
        {
            var isFormValid = editFormContext.Validate();

            if (isFormValid)
            {
                showValidationSummary = "display:block";
            }
            else
            {
                showValidationSummary = "display:none";
            }
        }

        public void Dispose()
        {
            editFormContext.OnFieldChanged -= HandleFormFieldChangedEvent;
        }
    }
}
