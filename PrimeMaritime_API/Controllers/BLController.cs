﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class BLController : ControllerBase
    {
        private IBLService _blService;
        public BLController(IBLService blService)
        {
            _blService = blService;
        }

        [HttpPost("InsertBL")]
        public ActionResult<Response<string>> InsertBL(BL request)
        {
            return Ok(_blService.InsertBL(request));
        }

        [HttpGet("GetBLDetails")]
        public ActionResult<Response<BL>> GetBLDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLDetails(BL_NO, BOOKING_NO, AGENT_CODE)));
        }

        [HttpGet("GetBLHistory")]
        public ActionResult<Response<List<BL>>> GetBLHistory(string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLHistory(AGENT_CODE)));
        }

        [HttpGet("GetBLFORMERGE")]
        public ActionResult<Response<List<BL>>> GetBLFORMERGE(string PORT_OF_LOADING, string PORT_OF_DISCHARGE, string SHIPPER, string CONSIGNEE, string VESSEL_NAME, string VOYAGE_NO, string NOTIFY_PARTY)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetBLFORMERGE(PORT_OF_LOADING, PORT_OF_DISCHARGE, SHIPPER, CONSIGNEE, VESSEL_NAME, VOYAGE_NO, NOTIFY_PARTY)));
        }

        [HttpGet("GetSRRDetails")]
        public ActionResult<Response<SRR>> GetSRRDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetSRRDetails(BL_NO, BOOKING_NO, AGENT_CODE)));
        }

        [HttpGet("GetContainerList")]
        public ActionResult<Response<List<CONTAINERS>>> GetContainerList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO,string BL_NO,string DO_NO,bool fromDO)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetContainerList(AGENT_CODE, DEPO_CODE, BOOKING_NO, CRO_NO,BL_NO,DO_NO,fromDO)));
        }

        [HttpGet("GetCargoManifestList")]
        public ActionResult<Response<CargoManifest>> GetCargoManifestList(string AGENT_CODE, string VESSEL_NAME, string VOYAGE_NO)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetCargoManifestList(AGENT_CODE, VESSEL_NAME, VOYAGE_NO)));
        }

        [HttpPost("UpdateBL")]
        public ActionResult<Response<string>> UpdateBL(BL request)
        {
            return Ok(_blService.UpdateBL(request));
        }


    }
}
