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
    public class ReimbursementService:IReimbursementService
    {
        private readonly IReimbursementRepository _reimbursementRepository;
        private IMapper mapper;

        public async Task<ReimbursementDTO> GetReimbursement(int id)
        {
            var result = await _reimbursementRepository.GetReimbursement(id);
            return mapper.Map<ReimbursementDTO>(result);
        }
        public ReimbursementService(IReimbursementRepository reimbursementRepository,IMapper mapper)
        {
            this._reimbursementRepository = reimbursementRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ReimbursementDTO>> GetAllReimbursements()
        {
            var result = await _reimbursementRepository.GetAllReimbursements(); 
            return mapper.Map<IList<ReimbursementDTO>>(result);
        }

        public async Task<IList<ReimbursementDTO>> GetReimbursementByEmail(string email)
        {
            var result = await _reimbursementRepository.GetReimbursementByEmail(email);
            return mapper.Map<IList<ReimbursementDTO>>(result);
        }


        public async Task<ReimbursementDTO> AddReimbursement(ReimbursementDTO reimbursement)
        {
            ReimbursementDomain reimbursementData = mapper.Map<ReimbursementDTO, ReimbursementDomain>(reimbursement);
            var result= await _reimbursementRepository.AddReimbursement(reimbursementData);
            return mapper.Map<ReimbursementDTO>(result);
        }

        public async Task<ReimbursementDTO> DeleteReimbursement(int id)
        {
            var reimbursement = await _reimbursementRepository.GetReimbursement(id);
            if (reimbursement != null)
            {
                var result = await _reimbursementRepository.DeleteReimbursement(id);
                return mapper.Map<ReimbursementDTO>(result);
            }

            return null;
        }

        public async Task<ReimbursementDTO> UpdateReimbursement(int id, ReimbursementDTO reimbursement)
        {
            var reimbursementToBeUpdated = await _reimbursementRepository.GetReimbursement(id);
            if (reimbursementToBeUpdated != null)
            {
                ReimbursementDomain reimbursementData = mapper.Map<ReimbursementDTO, ReimbursementDomain>(reimbursement);
                var result= await _reimbursementRepository.UpdateReimbursement(id, reimbursementData);
                return mapper.Map<ReimbursementDTO>(result);
            }

            return null;
        }

    }
}
