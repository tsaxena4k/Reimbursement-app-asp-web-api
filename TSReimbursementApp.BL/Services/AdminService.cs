using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.BL.Services.Interfaces;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.DTOs;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.BL.Services
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            this._adminRepository = adminRepository;
            this._mapper = mapper;
        }

        public async Task<ReimbursementDTO> ApproveReimbursement(int id,ReimbursementDTO reimbursement)
        {
            ReimbursementDomain reimbursement1 = _mapper.Map<ReimbursementDTO, ReimbursementDomain>(reimbursement);
            var result = await _adminRepository.ApproveReimbursement(id,reimbursement1);
            return _mapper.Map<ReimbursementDTO>(result);
        }

        public async Task<ReimbursementDTO> DeclineReimbursement(int id)
        {
            var result = await _adminRepository.DeclineReimbursement(id);
            return _mapper.Map<ReimbursementDTO>(result);
        }
    }
}
