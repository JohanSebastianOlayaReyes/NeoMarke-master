using Microsoft.Extensions.Logging;

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

        public async Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync()
        {
            try
            {
                var companies = await _companyData.GetAllCompaniesAsync();
                var companyDTO = new List<CompanyDTO>();

                foreach (var company in companies)
                {
                    companyDTO.Add(new CompanyDTO
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Address = company.Address,
                        Phone = company.Phone,
                        Email = company.Email
                    });
                }
                return companyDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving companies");
                throw new ExternalServiceException("base de datos", "Error al recuperar la lista de companies", ex);
            }
        }

        public async Task<CompanyDTO> GetCompanyDTOAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid company ID: {CompanyId}", id);
                throw new Utilities.Exceptions.ValidationException("id", "El id del company no puede ser menor o igual a 0");
            }
            try
            {
                var company = await _companyData.GetCompanyAsync(id);
                if (company == null)
                {
                    _logger.LogInformation("no se encontro ningun company con ID: {CompanyID}", id);
                    throw new EntityNotFoundException("Company", id);
                }

                return new CompanyDTO
                {
                    Id = company.Id,
                    Name = company.Name,
                    Address = company.Address,
                    Phone = company.Phone,
                    Email = company.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la empresa con ID: {CompanyID}", id);
                throw new ExternalServiceException("base de datos", $"Error al recuperar la empresa con ID: {id}", ex);
            }
        }

        public async Task<CompanyDTO> CreateCompanyAsync(CompanyDTO companyDTO)
        {
            try
            {
                ValidateCompany(companyDTO);

                var company = new Company
                {
                    Id = companyDTO.Id,
                    Name = companyDTO.Name,
                    Address = companyDTO.Address,
                    Phone = companyDTO.Phone,
                    Email = companyDTO.Email
                };
                var companyCreated = await _companyData.CreateCompanyAsync(company);
                return new CompanyDTO
                {
                    Id = companyCreated.Id,
                    Name = companyCreated.Name,
                    Address = companyCreated.Address,
                    Phone = companyCreated.Phone,
                    Email = companyCreated.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la empresa: {CompanyName}", companyDTO?.Name ?? "null");
                throw new ExternalServiceException("base de datos", "Error al crear la empresa", ex);
            }
        }

        private void ValidateCompany(CompanyDTO companyDTO)
        {
            if (companyDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto empresa no puede ser nulo");
            }
            if (string.IsNullOrWhiteSpace(companyDTO.Name))
            {
                throw new Utilities.Exceptions.ValidationException("name", "El nombre de la empresa es obligatorio ");
            }
        }

    }
}
