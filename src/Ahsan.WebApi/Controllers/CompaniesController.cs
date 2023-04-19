﻿using Ahsan.Service.DTOs.Companies;
using Ahsan.Service.Interfaces;
using Ahsan.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ahsan.WebApi.Controllers;

public class CompaniesController : BaseController
{
    private readonly ICompanyService companyService;
    public CompaniesController(ICompanyService companyService)
    {
        this.companyService = companyService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostCompanyAsync(CompanyForCreationDto dto)
        => Ok(new Response { Data = await this.companyService.CreateAsync(dto) });

    [HttpPut("update")]
    public async Task<IActionResult> PutCompanyAsync(CompanyForUpdateDto dto)
        => Ok(await this.companyService.ModifyAsync(dto));

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteCompany(long id)
        => Ok(await this.companyService.DeleteAsync(id));

    [HttpGet("get-by-id/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(await this.companyService.GetByIdAsync(id));

    [HttpGet("get-list")]
    public async Task<IActionResult> GetAllCompany()
        => Ok(await this.companyService.GetAllAsync());
}
