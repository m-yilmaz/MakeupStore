﻿using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class BasketWithItemsSpecification : Specification<Basket>
    {
        public BasketWithItemsSpecification(string buyerId)
        {
            Query.Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .Where(x => x.BuyerId == buyerId);
        }
    }
}
