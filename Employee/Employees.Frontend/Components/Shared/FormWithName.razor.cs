using Employees.Shared.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Employees.Frontend.Components.Shared;

public partial class FormWithName<TModel> where TModel : IEntityWithName
{
    private EditContext editContext = null!;

    [EditorRequired, Parameter] public TModel Model { get; set; } = default!;
    [EditorRequired, Parameter] public string Label { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    [Inject] private IDialogService DialogService { get; set; } = null!;

    public bool FormPostedSuccessfully { get; set; }

    protected override void OnInitialized()
    {
        editContext = new(Model);
    }
}
