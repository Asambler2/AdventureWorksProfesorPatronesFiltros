using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class Ejercicio04Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;

        public Ejercicio04Builder()
        {
            IProductSpecification PorInicio = new NameComienzaSpecification()
            {
                letras = ["A", "B", "C"]
            };
            IProductSpecification PorColor = new ProductColorSpecification()
            {
                colores = ["RED", "BLACK", "BLUE"]
            };
            especificacion = new AndSpecification()
            {
                Spec1 = PorInicio,
                Spec2 = PorColor
            };
            IProductSpecification PorListPrice = new ListPriceSpecification()
            {
                Price = 2
            };
            especificacion = new AndSpecification()
            {
                Spec1 = especificacion,
                Spec2 = PorListPrice
            };
        }
        public IEnumerable<Product> dameProductos(IEnumerable<Product> products)
        {
            return products.Where(x => especificacion.isValid(x)).OrderBy(x => x.Name);
        }
        public bool isValid(Product _producto)
        {
            return especificacion.isValid(_producto);
        }
    }
}
