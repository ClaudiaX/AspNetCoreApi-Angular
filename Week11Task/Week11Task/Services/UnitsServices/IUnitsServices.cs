using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week11Task.Models;

namespace Week11Task.Services.UnitsServices
{
    public interface IUnitsServices
    {
        Task<ServiceResponse<List<Unit>>> GetUnits();
        Task<ServiceResponse<Unit>> GetUnit(int id);
        Task<ServiceResponse<Unit>> CreateUnit(Unit unit);
        Task<ServiceResponse<Unit>> UpdateUnit(Unit unit);
        Task<ServiceResponse<string>> DeleteUnit(int id);
    }
}
