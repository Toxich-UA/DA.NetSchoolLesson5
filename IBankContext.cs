using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Lesson4.Model;

namespace Lesson4.Entity
{
    public interface IBankContext : IDisposable
    {
        IDbSet<Clients> Clients { get; set; }
        IDbSet<Cards> Cards { get; set; }
        IDbSet<Addresses> Addresseses { get; set; }
        IDbSet<Operations> Operations { get; set; }


        int Save();
        
    }
}