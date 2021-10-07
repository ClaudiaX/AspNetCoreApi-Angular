using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week11Task.Data;
using Week11Task.Models;

namespace Week11Task.Services.UnitsServices
{
    public class UnitsServices : IUnitsServices
    {
        private readonly ApplicationDbContext context;

        public UnitsServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<Unit>> CreateUnit(Unit unit)
        {
            var response = new ServiceResponse<Unit>();
            try 
            {
                var result = await context.AddAsync(unit);
                await context.SaveChangesAsync();
                response.Data = result.Entity;
            }
            catch(Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteUnit(int id)
        {
            var response = new ServiceResponse<string>();
            try 
            {
                var unit = await context.Units.FirstAsync(u => u.Id == id);
                context.Units.Remove(unit);
                await context.SaveChangesAsync();
            }
            catch(Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Unit>> GetUnit(int id)
        {
            var response = new ServiceResponse<Unit>();
            try
            {
                response.Data = await context.Units.FirstAsync(u => u.Id == id);
            }
            catch (Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Unit>>> GetUnits()
        {
            var response = new ServiceResponse<List<Unit>>();
            try 
            {
                response.Data = await context.Units.ToListAsync();
            }
            catch (Exception exception) 
            {
                response.Success = false;
                response.Message = exception.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Unit>> UpdateUnit(Unit unit)
        {
            var response = new ServiceResponse<Unit>();
            try 
            { 
                context.Entry(unit).State = EntityState.Modified;
                await context.SaveChangesAsync();
                response.Data = unit;
            }
            catch (Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
            }
            return response;
        }
    }
}
