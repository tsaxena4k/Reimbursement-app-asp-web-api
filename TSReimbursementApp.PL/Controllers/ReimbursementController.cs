using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.BL.Services.Interfaces;
using TSReimbursementApp.DAL.DTOs;
using TSReimbursementApp.PL.Models;

namespace TSReimbursementApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReimbursementController : ControllerBase
    {
        private readonly IReimbursementService _reimbursementService;
        private IMapper _mapper;

        public ReimbursementController(IReimbursementService reimbursementService,IMapper mapper)
        {
            this._reimbursementService = reimbursementService;
            this._mapper = mapper;
        }

        [HttpGet("GetReimbursement/{id:int}")]
        //GET : /api/reimbursement/GetReimbursement
        public async Task<ReimbursementViewModel> GetReimbursement(int id)
        {
            var result = await _reimbursementService.GetReimbursement(id);
            return _mapper.Map<ReimbursementViewModel>(result);
        }

        [HttpGet("GetReimbursementByEmail")]
        //GET : /api/reimbursement/GetReimbursementByEmail
        public async Task<IList<ReimbursementViewModel>> GetReimbursementByEmail(string email)
        {
            var result = await _reimbursementService.GetReimbursementByEmail(email);
            return _mapper.Map<IList<ReimbursementViewModel>>(result);
        }


        [HttpGet("GetAll")]
        //GET : /api/reimbursement/GetAll

        public async Task<IList<ReimbursementViewModel>> GetAllReimbursements()
        {
            Debug.WriteLine("Hello");
            var result = await _reimbursementService.GetAllReimbursements();
            return _mapper.Map<IList<ReimbursementViewModel>>(result);
        }

        [HttpPost("AddReimbursement")]
        //POST : /api/reimbursement/AddReimbursement
        public async Task<ReimbursementViewModel> AddReimbursement(ReimbursementViewModel reimbursement)
        {
            ReimbursementDTO newReimbursement = _mapper.Map<ReimbursementViewModel, ReimbursementDTO>(reimbursement);
            var result = await _reimbursementService.AddReimbursement(newReimbursement);
            return _mapper.Map<ReimbursementViewModel>(result);
        }

        [HttpDelete("Delete/{id:int}")]
        //DELETE : /api/reimbursement/Delete

        public async Task<ActionResult<ReimbursementViewModel>> DeleteReimbursement(int id)
        {
                var reimbursementToDelete = await _reimbursementService.GetReimbursement(id);
                if (reimbursementToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                var result= await _reimbursementService.DeleteReimbursement(id);
                return _mapper.Map<ReimbursementViewModel>(result);
           
        }

        [HttpPut("Update/{id:int}")]
        //PUT : /api/reimbusement/Update

        public async Task<ActionResult<ReimbursementViewModel>> UpdateReimbursement(int id, ReimbursementViewModel reimbursement)
        {
            Debug.WriteLine("Update");
            var reimbursementToUpdate = await _reimbursementService.GetReimbursement(id);
            if (reimbursementToUpdate == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            ReimbursementDTO reimbursementData = _mapper.Map<ReimbursementViewModel, ReimbursementDTO>(reimbursement);
            var result = await _reimbursementService.UpdateReimbursement(id, reimbursementData);
            return _mapper.Map<ReimbursementViewModel>(result);
        }

    }
}
