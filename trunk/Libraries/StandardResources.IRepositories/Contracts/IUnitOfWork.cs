using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardResources.IRepositories.Contracts
{
    public interface IUnitOfWork
    {

        int complete();
    }
}
