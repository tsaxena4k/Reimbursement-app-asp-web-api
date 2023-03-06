﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.DAL.Repositories
{
    public class InMemoryRefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();

        public Task Create(RefreshToken refreshToken)
        {
            //refreshToken.Id = Guid.NewGuid();

            _refreshTokens.Add(refreshToken);

            return Task.CompletedTask;
        }

        public Task<RefreshToken> GetByToken(string token)
        {
            RefreshToken refreshToken = _refreshTokens.FirstOrDefault(r => r.Token == token);

            return Task.FromResult(refreshToken);
        }

        public Task Delete(int id)
        {
            _refreshTokens.RemoveAll(r => r.Id == id);

            return Task.CompletedTask;
        }

        public Task DeleteAll(string userId)
        {
            _refreshTokens.RemoveAll(r => r.UserId == userId);

            return Task.CompletedTask;
        }
    }
}
