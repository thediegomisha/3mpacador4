using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Entidad.Reportes
{
    public class CreateBoletaDetalle
    {
        public static BoletaModel ObtenerDetalleBoleta()
        {
            return new BoletaModel
            {

                Numlote = 0,
                //InvoiceNumber = _random.Next(1_000, 10_000),
                //IssueDate = DateTime.Now,
                //DueDate = DateTime.Now + TimeSpan.FromDays(14),
                //SellerCompanyName = "追逐时光者",
                //CustomerCompanyName = "DotNetGuide技术社区",
                //OrderItems = Enumerable
                //.Range(1, 20)
                //.Select(_ => GenerateRandomOrderItemInfo())
                //.ToList()
            };
        }
    }
}
