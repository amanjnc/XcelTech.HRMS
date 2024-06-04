using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Bloc.IService
{
    public  interface IAutoGenerateId
    {
        //string GenerateRandomPassword(int length = 10);
        string GenerateUniqueId(int length = 11);
    }
}
