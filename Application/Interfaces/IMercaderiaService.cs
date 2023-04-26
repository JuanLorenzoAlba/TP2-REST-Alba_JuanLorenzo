﻿using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMercaderiaService
    {
        MercaderiaResponse GetMercaderiaById(int mercaderiaId);
        List<MercaderiaGetResponse> GetMercaderiaListOrdered(int tipo, string nombre, string orden);
        List<Mercaderia> GetMercaderiaList();
        MercaderiaResponse CreateMercaderia(MercaderiaRequest request);
        MercaderiaResponse RemoveMercaderia(int mercaderiaId);
        MercaderiaResponse UpdateMercaderia(int mercaderiaId, MercaderiaRequest request);
    }
}
