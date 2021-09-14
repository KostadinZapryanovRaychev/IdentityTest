using NetCoreFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// tuka mai sha praim nai razlichni funkciii crud i razni drugi  au a i drugi shturotiii i shte gi polzvame posle po kontrolerite

namespace NetCoreFromScratch.Data
{
    public interface IRepository
    {
        Task InsertIntoDB(Customer customer);
    }
}

// tva i interfeca sq sha narpaim i klas Repositoruy v koito shte implementirame toq interfeis