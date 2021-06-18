using Dtos;
using System;
using System.Linq;
using Tienda.Dto;
using Tienda.Logic;

namespace Tienda.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalize = false;
            var logic = new ProductLogic();

            while (!finalize)
            {
                Console.WriteLine
(@"Seleccione una operación

1. Listado de productos

2. Crear producto

3. Eliminar producto

4. Modificar producto

5. Salir
");

                var input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        {

                            var products = logic.ListProducts();
                            if (!products.Any())
                            {
                                Console.WriteLine("No hay productos");
                                Console.WriteLine("Presione cualquier tecla para regresar");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            foreach (var product in products)
                            {
                                Console.WriteLine(@$"Id: {product.Id} | Nombre: {product.Name} | Descripción: {product.Description} | Precio: {product.Price} | Categoría: {product.CategoryId} | Estado: { product.Status}
                                 ");
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        };
                    case "2":
                        {

                            var newProduct = RequestProductData();

                            if (newProduct != null)
                            {
                                try
                                {
                                    logic.CreateProduct(newProduct);
                                    Console.Clear();
                                    Console.WriteLine("Producto creado");
                                    Console.WriteLine("Presione cualquier tecla para regresar");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Presione cualquier tecla para regresar");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }

                            break;
                        };
                    case "3":
                        {

                            Console.WriteLine("Ingrese id:");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.Clear();
                                Console.WriteLine("Id incorrecto");
                                Console.WriteLine("Presione cualquier tecla para regresar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            if (logic.ValidateUserInput(id, "orderlines") == 1) 
                            {
                                Console.Clear();
                                Console.WriteLine("El producto que intentas eliminar es mencionado en dbo.OrderLines, no se puede eliminar");
                                Console.WriteLine("Presione cualquier tecla para regresar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            try
                            {
                                var success = logic.DeleteProduct(id);
                                if (success)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Producto eliminado");
                                    Console.WriteLine("Presione cualquier tecla para regresar");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("No se encontró el producto");
                                Console.WriteLine("Presione cualquier tecla para regresar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        };
                    case "4":
                        {

                            Console.WriteLine("Ingrese id:");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.Clear();
                                Console.WriteLine("Id incorrecto");
                                Console.WriteLine("Presione cualquier tecla para regresar");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            try
                            {
                                var product = logic.GetProduct(id);
                                if (product != null)
                                {
                                    Console.WriteLine("");
                                    var newProductData = RequestProductData();
                                    if (newProductData != null)
                                    {
                                        newProductData.Id = id;
                                        logic.UpdateProduct(newProductData);
                                        Console.Clear();
                                        Console.WriteLine("Producto modificado");
                                        Console.WriteLine("Presione cualquier tecla para regresar");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("No se encontró el producto");
                                Console.WriteLine("Presione cualquier tecla para regresar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        };
                    case "5":
                        {
                            finalize = true;
                            break;
                        };
                    default:
                        {
                            Console.WriteLine("Opcion incorrecta");
                            Console.WriteLine("Presione cualquier tecla para regresar");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        };
                }
            }
        }

        private static Product RequestProductData()
        {
            var productData = new Product();
            var logic = new ProductLogic();
            string name;

            Console.WriteLine("Ingrese nombre:");
            name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.Clear();
                Console.WriteLine("Nombre incorrecto");
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            else
            {
                productData.Name = name;
            }

            Console.WriteLine("");
            Console.WriteLine("Ingrese descripción:");
            productData.Description = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Ingrese precio:");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Clear();
                Console.WriteLine("Precio incorrecto");
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            else
            {
                productData.Price = price;
            }

            Console.WriteLine("");
            Console.WriteLine("Ingrese categoría:");
            int categoryId;
            if (!int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Clear();
                Console.WriteLine("Categoría incorrecta");
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            else
            {
                if(logic.ValidateUserInput(categoryId, "category") == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Categoría no existente");
                    Console.WriteLine("Presione cualquier tecla para regresar");
                    Console.ReadKey();
                    Console.Clear();
                    return null;
                }
                else
                {
                    productData.CategoryId = categoryId;
                }
                
            }

            Console.WriteLine("");
            Console.WriteLine("Ingrese estado:");
            int status;
            if (!int.TryParse(Console.ReadLine(), out status))
            {
                Console.Clear();
                Console.WriteLine("Estado incorrecto");
                Console.WriteLine("Presione cualquier tecla para regresar");
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            else
            {
                if(logic.ValidateUserInput(status, "status") == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Estado no existente");
                    Console.WriteLine("Presione cualquier tecla para regresar");
                    Console.ReadKey();
                    Console.Clear();
                    return null;
                }
                else 
                {
                    productData.Status = (ProductStatus)status;
                }
  
            }

            return productData;
        }
    }
}