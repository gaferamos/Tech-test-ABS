using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS_System
{
    internal class ConstrutorPedido
    {
        private Dictionary<string, List<string>> bebidas = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        { 
            {"Refrigerante",new List<string> {"Coca","Guarana"}},
            {"Suco",new List<string> {"Uva","Laranja"}}
        };

        public string drinkType { get  ; private set; }
        public string drinkFlavor { get; private set; }
        public string drinkSize { get; private set; }
        public string orderType { get; private set; }

        public ConstrutorPedido()
        {
             this.drinkType = GetDrinkType();
             this.drinkFlavor = GetDrinkFlavor(drinkType);
             this.drinkSize = GetDrinkSize(drinkType);
             this.orderType = GetOrderType();
        }



        private string GetDrinkType ()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tipos de bebida: ");
                foreach (var drink in bebidas)
                {
                    Console.WriteLine(drink.Key);
                }

                Console.Write("Escolha o tipo de bebida: ");
                try
                {
                    var drinkType = Console.ReadLine();
                    if (drinkType != null)
                    {
                        if (bebidas.ContainsKey(drinkType))
                        {
                            return bebidas.First(kvp => string.Equals(kvp.Key, drinkType, StringComparison.OrdinalIgnoreCase)).Key;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                Console.WriteLine("invalido, escreva o tipo de bebida que deseja");
                Console.ReadKey();
            }
            
        }


        private string GetDrinkFlavor(string drinkType)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sabores de bebida: ");
                if (bebidas.TryGetValue(drinkType, out var flavors))
                {
                    foreach (var flavor in flavors)
                    {
                        Console.WriteLine(flavor);
                    }
                }
                Console.Write(format: "Escolha um sabor de {0}: ", drinkType);
                try
                {
                    var drinkFlavor = Console.ReadLine();
                    if (drinkFlavor != null)
                    {
                        drinkFlavor = flavors.FirstOrDefault(f => string.Equals(f, drinkFlavor, StringComparison.OrdinalIgnoreCase));
                        if (drinkFlavor != null)
                        {
                            return drinkFlavor;

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                Console.WriteLine("invalido, escreva o sabor de bebida que deseja");
                Console.ReadKey();
            }
        }
        
        private string GetDrinkSize(string drinkType)
        {
            ushort[] drinksize = new ushort[] { 300, 500, 700 };
            switch (drinkType)
            {
                case "Refrigerante":
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Tamanho de bebida: ");
                        for (int i = 0; i < drinksize.Length; i++)
                        {
                            Console.WriteLine(format: " {0} - {1}ml", i + 1, drinksize[i]);
                        }
                        Console.Write("Escolha o tamanho da bebida: ");
                        try
                        {
                            if (ushort.TryParse(Console.ReadLine(), out ushort option))
                            {
                                if (option > 0 && option <= drinksize.Length)
                                {
                                    return (drinksize[option - 1]).ToString();

                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }

                        Console.Write("invalido, escolha um valor que represente o tamanho desejado de bebida ");
                        Console.ReadKey();
                    }
                }

                case "Suco":
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Tamanho de bebida: ");
                        for (int i = 0; i < drinksize.Length - 1; i++)
                        {
                            Console.WriteLine(format: " {0} - {1}ml", i + 1, drinksize[i]);
                        }
                        Console.Write("Escolha o tamanho da bebida: ");
                        try
                        {
                            if (ushort.TryParse(Console.ReadLine(), out ushort option))
                            {
                                if (option > 0 && option <= drinksize.Length - 1)
                                {
                                    return (drinksize[option - 1]).ToString();

                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }

                        Console.Write("invalido, escolha um valor que represente o tamanho desejado de bebida ");
                        Console.ReadKey();
                    }

                }

                default:
                {
                    return "";
                }
            }
            
        }

        private string GetOrderType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tipo do pedido:");
                var typeOfOrder = new string[] { "Viagem", "Local" };
                for (int i = 0; i < typeOfOrder.Length; i++)
                {
                    Console.WriteLine(format: "{0} - {1}", i + 1, typeOfOrder[i]);
                }
                Console.WriteLine("Escolha o tipo de seu pedido");
                try
                {
                    if (ushort.TryParse(Console.ReadLine(), out ushort option))
                    {
                        if (option > 0 && option <= typeOfOrder.Length)
                        {
                            return typeOfOrder[option - 1].ToLower();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                Console.WriteLine("invalido digite o valor correspondente ao tipo do pedio");
                Console.ReadKey();
            }
           
        }
    }
}
