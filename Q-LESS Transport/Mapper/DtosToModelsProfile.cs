using AutoMapper;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Dtos.Card;
using Q_LESS_Transport.Dtos.DiscountCard;
using Q_LESS_Transport.Dtos.Transaction;

namespace Q_LESS_Transport.Mapper
{
    public class DtosToModelsProfile : Profile
    {
        public DtosToModelsProfile()
        {
            CreateMap<SaveCardResource, Card>();
            CreateMap<SaveDiscountCardResource, DiscountCard>();
            CreateMap<SaveTransactionResource, Transaction>();
        }
    }
}
