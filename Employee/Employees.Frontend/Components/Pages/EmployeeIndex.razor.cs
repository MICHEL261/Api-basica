using Employees.Frontend.Components.Shared;
using Employees.Frontend.Repositories;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace Employees.Frontend.Components.Pages;

public partial class EmployeeIndex
{
    private List<Employee>? Employees;
    
    [Inject] private IRepository Repository { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        var httpResult = await Repository.GetAsync<List<Employee>>("/api/Employee");
        Employees=httpResult.Response;
    }
}

   