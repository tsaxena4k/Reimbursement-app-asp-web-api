using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.BL.Services.Interfaces;
using TSReimbursementApp.DAL.DTOs;
using TSReimbursementApp.PL.Models;

namespace TSReimbursementApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private IMapper _mapper;

        public AdminController(IAdminService adminService,IMapper mapper)
        {
            this._adminService = adminService;
            this._mapper = mapper;
        }

        [HttpPut("ApproveReimbursement/{id:int}")]
        //PUT : /api/Admin/ApproveReimbursement
        public async Task<ReimbursementViewModel> ApproveReimbursement(int id, ReimbursementViewModel reimbursement)
        {
            ReimbursementDTO reimbursement1 = _mapper.Map<ReimbursementViewModel, ReimbursementDTO>(reimbursement);
            var result = await _adminService.ApproveReimbursement(id, reimbursement1);
            return _mapper.Map<ReimbursementViewModel>(result);
        }

        [HttpPut("DeclineReimbursement/{id:int}")]
        //PUT : /api/Admin/DeclineReimbursement
        public async Task<ReimbursementViewModel> DeclineReimbursement(int id)
        {
            var result = await _adminService.DeclineReimbursement(id);
            return _mapper.Map<ReimbursementViewModel>(result);
        }

    }
}
