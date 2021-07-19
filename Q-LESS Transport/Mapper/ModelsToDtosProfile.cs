using AutoMapper;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Dtos.Card;
using Q_LESS_Transport.Dtos.CardTypeDetails;
using Q_LESS_Transport.Dtos.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Mapper
{
    public class ModelsToDtosProfile : Profile
    {
        public ModelsToDtosProfile()
        {
            CreateMap<Card, CardResource>();
            CreateMap<Transaction, TransactionResource>();
            CreateMap<CardTypeDetails, CardTypeDetailsResource>();
        }
    }
}
