using RocketSeatSolution.API.Comunication.Request;
using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.Services;

namespace RocketSeatSolution.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly UsuarioLogado _usuarioLogado;
    private readonly IRepositorioOferta _repositorioOferta;
    public CreateOfferUseCase(UsuarioLogado UsuarioAtivo, IRepositorioOferta repositorio)
    {
        _usuarioLogado = UsuarioAtivo;
        _repositorioOferta = repositorio;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var usuario = _usuarioLogado.Usuario();
        var oferta = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = usuario.Id,
        };

        _repositorioOferta.Adicionar(oferta);
        return oferta.Id;
    }
}
