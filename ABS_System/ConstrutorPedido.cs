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
            selectdrink:
            Console.Clear();
            Console.WriteLine("Tipos de bebida: ");
            foreach (var drink in bebidas)
            {  
                Console.WriteLine(drink.Key);
                
            }

            try
            {
                Console.WriteLine("Escolha o tipo de bebida: ");
                var drinkType = Console.ReadLine();
                if (bebidas.ContainsKey(drinkType))
                {
                    drinkType = bebidas.First(kvp => string.Equals(kvp.Key, drinkType, StringComparison.OrdinalIgnoreCase)).Key;
                }
                else
                {
                    goto selectdrink;
                }


                return drinkType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private string GetDrinkFlavor(string drinkType)
        {
            selectflavor:
            Console.Clear();
            Console.WriteLine("Sabores de bebida: ");
            if (bebidas.TryGetValue(drinkType, out var flavors))
            {
                foreach (var flavor in flavors)
                {
                    Console.WriteLine(flavor);
                }
            }

            try
            {
                Console.WriteLine(format: "Escolha um sabor de {0}: ", drinkType);
                var drinkFlavor = Console.ReadLine();

                drinkFlavor = flavors.FirstOrDefault(f => string.Equals(f, drinkFlavor, StringComparison.OrdinalIgnoreCase));

                if (drinkFlavor != null)
                {
                    return drinkFlavor;
                }
                else
                {
                    goto selectflavor;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private string GetDrinkSize(string drinkType)
        {
            ushort[] drinksize = new ushort[] { 300, 500, 700 };
            string size = "";

            selectdeinksize:
            Console.Clear();
            Console.WriteLine("Tamanho de bebida: ");
            if (drinkType == "Refrigerante")
            {
                
                for (int i = 0; i < drinksize.Length; i++)
                {
                    Console.WriteLine(format: " {0} - {1}ml", i + 1, drinksize[i]);
                }

                try
                {
                    Console.Write("Escolha o tamanho da bebida: ");
                    ushort.TryParse(Console.ReadLine(), out ushort option);
                    if (option < 1 || option > drinksize.Length)
                    {
                        goto selectdeinksize;
                    }
                    size = (drinksize[option - 1]).ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
            if (drinkType == "Suco")
            {
                
                for (int i = 0; i < drinksize.Length - 1; i++)
                {
                    Console.WriteLine(format: " {0} - {1}ml", i + 1, drinksize[i]);
                }

                try
                {
                    Console.Write("Escolha o tamanho da bebida: ");
                    ushort.TryParse(Console.ReadLine(), out ushort option);

                    if (option < 1 || option > drinksize.Length - 1)
                    {
                        goto selectdeinksize;
                    }

                    size = (drinksize[option - 1]).ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return size;
        }

        private string GetOrderType()
        {
            selectOrderType:
            Console.Clear();
            Console.WriteLine("Tipo do pedido:");
            var typeOfOrder = new string[] { "Viagem", "Local" };
            for (int i = 0; i < typeOfOrder.Length; i++)
            {
                Console.WriteLine(format:"{0} - {1}", i + 1, typeOfOrder[i]);
            }

            try
            {
                Console.WriteLine("Tipo do pedido:");
                ushort.TryParse(Console.ReadLine(), out ushort option);

                if (option < 1 || option > typeOfOrder.Length)
                {
                    goto selectOrderType;
                }
                return typeOfOrder[option - 1].ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
