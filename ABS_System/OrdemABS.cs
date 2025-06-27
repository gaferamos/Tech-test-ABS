using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ABS_System
{
    internal class OrdemABS
    {
        public string drinkType { get; private set; }
        public string drinkFlavor { get; private set; }
        public string drinkSize { get; private set; }
        public string orderType { get; private set; }
        public string cupType { get; private set; }
        public int iceAmount { get; private set; }
        public string coverType { get; private set; }



        public static void GetOrdersABS()
        {
            var orderToSend = new ConstrutorPedido();

            
            var ordem = new OrdemABS();

            ordem.drinkType = orderToSend.drinkType;
            ordem.drinkFlavor = orderToSend.drinkFlavor;
            ordem.drinkSize = orderToSend.drinkSize;
            ordem.orderType = orderToSend.orderType;

            

            ordem.EnviarOrdemAoABS(ordem.drinkType, ordem.drinkFlavor, ordem.drinkSize, ordem.orderType);
        }

        private void EnviarOrdemAoABS(string drinkType, string drinkFlavor, string drinkSize, string orderType)
        {
            cupType = drinkType == "Suco" ? "Plastico" : "Papel";
            iceAmount = drinkType == "Suco" ? 12 : 6;
            coverType = orderType == "local" ? "Tampa furada" : "Tampa lacrada";
            
            Console.Clear();
            Console.WriteLine("adicionar gelo [s/n]");
            var iceoption = Console.ReadLine().ToLower();
            while (iceoption != "s" && iceoption != "n")
            {
                Console.Clear();
                Console.WriteLine("adicionar gelo [s/n]");
                iceoption = Console.ReadLine().ToLower();
            }

            if (iceoption == "n")
            {
                iceAmount = 0;
            }
            Console.WriteLine($"A bebida selecionada {drinkType} {drinkFlavor}, foi servida em: Copo de {cupType}, Contendo: {iceAmount} pedras de gelo, com {drinkSize}ml, e {coverType}");
            Console.ReadKey();
        }



    }
}
