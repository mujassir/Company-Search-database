﻿using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly RepositoryContext _context;
        public CompanyRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllWithStaffMembersAsync()
        {
            return await _context.Companies
                .Include(company => company.StaffMembers)
                .ToListAsync();
        }

        public async Task<Company> GetByIdWithStaffMembersAsync(int id)
        {
            var company = await _context.Companies
                .Where(company => company.Id == id)
                .Include(company => company.StaffMembers)
                .Include(company => company.Category)
                .Include(company => company.Projects)
                .FirstOrDefaultAsync();
            return company;
        }
        
        public async Task<Company> GetByIdWithProgramsAsync(int id)
        {
            var company = await _context.Companies
                .Where(company => company.Id == id)
                .Include(company => company.Category)
                .Include(company => company.Programs)
                .FirstOrDefaultAsync();
            return company;
        }

        public async Task<IEnumerable<Company>> SearchCompanyAsync(string? country, string? region, int[] categoryId, string? company, string? website)
        {
            return await _context.Companies
                .Include(c => c.Category)
                .Where(s =>
                    (string.IsNullOrEmpty(country) || s.Country.Contains(country)) &&
                    (string.IsNullOrEmpty(region) || s.Region.Contains(region)) &&
                    (categoryId == null || categoryId.Contains(s.CategoryId)) &&
                    (string.IsNullOrEmpty(company) || s.Name.Contains(company)) &&
                    (string.IsNullOrEmpty(website) || s.Website.Contains(website)))
                .ToListAsync();
        }
    }
}
