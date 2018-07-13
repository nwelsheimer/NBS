using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiracleSkate
{
    class StockforOpenmiracle
    {
        public decimal ProductId { get; set; }
        public decimal UnitID{get; set;}
        public decimal BatchId { get; set; }
        public bool OpeningStock { get; set; }
        public decimal OpeningStockNumber { get; set; }
        public decimal ClosingRate { get; set; }
    }
}
