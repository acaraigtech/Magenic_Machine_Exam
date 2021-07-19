using AutoMapper;
using Q_LESS_Transport.Dtos.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Mapper
{
    public class DtosToDtosProfile : Profile
    {
        public DtosToDtosProfile()
        {
            CreateMap<SaveTransactionResource, TransactionResource>();
            CreateMap<TransactionResource, SaveTransactionResource>();
        }
    }
}
