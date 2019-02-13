﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class Cart
    {
        private List<Cartline> lineCollection = new List<Cartline>();

        public virtual void AddItem(Product product, int quantity)
        {
            Cartline line = lineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new Cartline
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(p => p.Product.Price * p.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<Cartline> Lines => lineCollection;
    }

    public class Cartline
    {
        public int CartlineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
