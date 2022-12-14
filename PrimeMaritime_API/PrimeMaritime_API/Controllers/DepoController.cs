﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepoController : ControllerBase
    {
        private IDepoService _depoService;
        public DepoController(IDepoService depoService)
        {
            _depoService = depoService;
        }

        [HttpPost("InsertContainer")]
        public ActionResult<Response<CommonResponse>> InsertContainer(DEPO_CONTAINER request)
        {
            return Ok(_depoService.InsertContainer(request));
        }

        [HttpPost("InsertMRRequest")]
        public ActionResult<Response<CommonResponse>> InsertMRRequest(List<MR_LIST> request)
        {
            return Ok(_depoService.InsertMRRequest(request));
        }

        [HttpPost("InsertNewMRRequest")]
        public ActionResult<Response<string>> InsertNewMRRequest(List<MR_LIST> request)
        {
            return Ok(_depoService.InsertNewMRRequest(request));
        }

        [HttpGet("GetMNRList")]
        public ActionResult<Response<List<MNR_LIST>>> GetMNRList(string OPERATION, string DEPO_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_depoService.GetMNRList(OPERATION, DEPO_CODE)));
        }

        [HttpGet("GetMRDetails")]
        public ActionResult<Response<List<MR_LIST>>> GetMRDetails(string OPERATION, string MR_NO)
        {
            return Ok(JsonConvert.SerializeObject(_depoService.GetMNRDetails(OPERATION, MR_NO)));
        }

        [HttpPost("ApproveRate")]
        public ActionResult<Response<CommonResponse>> ApproveRate(List<MR_LIST> request)
        {
            return Ok(_depoService.ApproveRate(request));
        }

        [HttpPost("DeleteMRequest")]
        public ActionResult<Response<string>> DeleteMRequest(string MR_NO, string LOCATION)
        {
            return Ok(_depoService.DeleteMRRequest(MR_NO, LOCATION));
        }

        [HttpPost("UploadMNRFiles")]
        public IActionResult UploadMNRFiles(string MR_NO)
        {
            var formFile = Request.Form.Files;

            string path = Path.Combine("Uploads", "MNRFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in formFile)
            {
                string fileName = Path.GetFileName(MR_NO + "_" + postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
            }

            return Ok();
        }

        //[HttpGet("GetImages")]
        //public IActionResult GetImages()
        //{
        //    try
        //    {
        //        var folderName = Path.Combine("Uploads", "MNRFiles");
        //        var pathToRead = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        var photos = Directory.EnumerateFiles(pathToRead)
        //            .Where(IsAPhotoFile)
        //            .Select(fullPath => Path.Combine(folderName, Path.GetFileName(fullPath)));
        //        return Ok(new { photos });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}
        //private bool IsAPhotoFile(string fileName)
        //{
        //    return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
        //        || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
        //        || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
        //}

        [HttpGet("GetImage")]
        public ActionResult<Response<List<string>>> GetImage(string MR_NO)
        {
            string[] array1 = Directory.GetFiles("Uploads\\MNRFiles");
            List<string> array2 = new List<string>();
            Response<List<string>> response = new Response<List<string>>();

            // Get list of files.
            List<string> filesList = array1.ToList();

            foreach (var file in filesList)
            {
                if (file.Contains(MR_NO))
                {
                    array2.Add(file);

                }
            }

            if (array2.Count > 0)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = array2;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }
            return response;
        }

        //[HttpGet("GetImage")]
        //public HttpResponseMessage GetImage(string fileName)
        //{

        //    string filePath = Path.Combine("Uploads", "MNRFiles");
        //    if (!Directory.Exists(filePath))
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);
        //    }
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = new StreamContent(new FileStream(Path.Combine(filePath, fileName), FileMode.Open, FileAccess.Read));
        //    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(fileName);
        //    response.Content.Headers.ContentLength = Path.Combine(filePath, fileName).Length;
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/*");
        //    return response;
        //}



    }
}
