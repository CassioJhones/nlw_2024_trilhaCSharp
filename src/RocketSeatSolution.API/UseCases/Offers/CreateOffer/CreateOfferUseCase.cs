using RocketSeatSolution.API.Comunication.Request;
using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.Repositories;
using RocketSeatSolution.API.Services;

namespace RocketSeatSolution.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly UsuarioLogado _usuarioLogado;
    public CreateOfferUseCase(UsuarioLogado UsuarioAtivo) => _usuarioLogado = UsuarioAtivo;
    
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repositorio = new RocketSeatSolutioinDBContext();
        var usuario = _usuarioLogado.User();
        var oferta = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = usuario.Id,
        };

        repositorio.Offers.Add(oferta);
        repositorio.SaveChanges();
        return oferta.Id;
    }
}
