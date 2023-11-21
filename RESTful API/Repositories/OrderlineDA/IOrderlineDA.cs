﻿using Models;

namespace RESTful_API.Repositories.OrderlineDA;

public interface IOrderlineDA : ICRUD<Orderline>
{
    Task<List<Orderline>> GetOrderlines(long id);
}