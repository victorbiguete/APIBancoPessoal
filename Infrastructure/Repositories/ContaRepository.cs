﻿using APIBanco.Core.Exceptions;
using APIBanco.Domain.Enum;
using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBanco.Infrastructure.Repositories
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepositoy
    {
        private readonly AppDbContext _context;

        public ContaRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Conta> GetByConta(string numero)
        {
            return await _context.Conta.AsNoTracking().Where(x=>x.Numero.Equals(numero) && x.Status.Equals(StatusServico.Ativo)).Include(x=>x.Titular).FirstOrDefaultAsync();
        }

        public async Task<List<Conta>> SearchByContaByCPF(string cpf)
        {
            return await _context.Conta.AsNoTracking().Where(x => x.Titular.Cpf.Equals(cpf)).ToListAsync();
        }

        public override async Task<List<Conta>> GetAll()
        {
            return await _context.Conta.AsNoTracking().Where(x => x.Status.Equals(StatusServico.Ativo)).ToListAsync();
        }
    }
}
