using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CompanyBusiness
    {
        private readonly CompanyData _companyData;
        private readonly ILogger _logger;

        public CompanyBusiness(CompanyData companyData, ILogger logger)
        {
            _companyData = companyData;
            _logger = logger;
        }

        //
        public async Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync()
        {
            try
            {
                var companies = await _companyData.GetAllCompaniesAsync();
                var companyDTO = new List<companyDTO();

                foreach ( var company in companies)
                {
                    companyDTO.Add( new CompayDTO
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Address = company.Address,
                        Phone = company.Phone,
                        Email = company.Email
                    });
                }
                {
                    
                }
            }
        }

    }
}
