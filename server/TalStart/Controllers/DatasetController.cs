﻿using Microsoft.AspNetCore.Mvc;
using TalStart.IServices;

namespace TalStart.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DatasetController : ControllerBase
{
    private readonly IDatasetService _datasetService;
    public DatasetController(IDatasetService datasetService)
    {
        _datasetService = datasetService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddDataset([FromForm] string username, [FromForm] string datasetName)
    {
        if(_datasetService.AddDataset(username, datasetName))
            return new OkResult();
        return new BadRequestResult();
    }

    [HttpDelete("/{datasetName}/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveDataset([FromRoute] string datasetName, [FromRoute] string username)
    {
        if(_datasetService.RemoveDataset(datasetName, username))
            return new OkResult();
        return new BadRequestResult();
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RenameDataset([FromForm] string currentDatasetName, [FromForm] string username, [FromForm] string newDatasetName)
    {
        if(_datasetService.RenameDataset(currentDatasetName, username, newDatasetName))  
            return new OkResult();
        return new BadRequestResult();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllDatasets([FromForm] string username)
    { 
        try
        {
            return Ok(_datasetService.GetAllDatasetNames(username));
        }
        catch (Exception)
        {
            return new BadRequestResult();
        }
    }

    [HttpGet("{count}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDatasetSample(int count)
    {
        await Task.Delay(3);
        return new BadRequestResult();
    }
}