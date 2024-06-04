using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface ICacheService
    {
        //public ReddisUniqueTokenWithUserIdDto GetData(string key);

        public Task<ReddisUniqueTokenWithUserIdDto> GetData(string key);
        public bool SetData<T>(string key, T value,  DateTimeOffset expirationTime);

        object RemoveData(string key);
    }
}