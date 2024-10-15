using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackExchange.Redis;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System.Text.Json;
using XcelTech.HRMS.Model.Dto;
//using Newtonsoft.Json;

namespace XcelTech.HRMS.Bloc.Service
{
    public class CacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }

        public async Task<ReddisUniqueTokenWithUserIdDto> GetData(string key)
        {
            var value = await _cacheDb.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<ReddisUniqueTokenWithUserIdDto>(value);
            }
            else
            {
                return default;
            }
        }

        //public ReddisUniqueTokenWithUserIdDto GetData(string key)
        //{
        //    try
        //    {
        //        var value = _cacheDb.StringGet(key);
        //        if (!string.IsNullOrEmpty(value))
        //            return JsonSerializer.Deserialize<ReddisUniqueTokenWithUserIdDto>(value);
        //        throw new Exception($"No data found in the cache for key: {key}");
        //    }
        //    catch (JsonException ex)
        //    {
        //        // Log the exception and handle it based on your application's requirements
        //        Console.WriteLine($"Error deserializing data from cache: {ex.Message}");
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and handle it based on your application's requirements
        //        Console.WriteLine($"Error getting data from cache: {ex.Message}");
        //        throw;
        //    }
        //}

        public object RemoveData(string key)
        {
            var _exists = _cacheDb.KeyExists(key);
            //if (string.IsNullOrEmpty(_exists))
            if (_exists)
                return _cacheDb.KeyDelete(key);
            return false;

        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var newValue = JsonSerializer.Serialize(value);
            var isSet = _cacheDb.StringSet(key, newValue, expiryTime);
            return isSet;
        }
    }
}