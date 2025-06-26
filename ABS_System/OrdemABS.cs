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

            Console.WriteLine($"A bebida selecionada {drinkType} {drinkFlavor}, foi servida em: Copo de {cupType}, Contendo: {iceAmount} pedras de gelo, com {drinkSize}ml, e {coverType}");
            Console.ReadKey();
        }






        //public void getOrdesABS()
        //{
        //    var orderToSand = new ConstrutorPedido();

        //    this.drinkType = orderToSand.drinkType;
        //    this.drinkFlavor = orderToSand.drinkFlavor;
        //    this.drinkSize = orderToSand.drinkSize;
        //    this.orderType = orderToSand.orderType;

        //    this.cupType = this.drinkType == "Suco"? "Plastico" : "Papel";
        //    this.iceAmount = this.drinkType == "Suco" ? 12 : 6 ;
        //    this.coverType = this.orderType == "local" ? "Tampa furada" : "Tampa lacrada";


        //    EnviarOrdemAoABS(this.drinkType, this.drinkFlavor,this.drinkSize,this.orderType,this.cupType,this.iceAmount,this.coverType);


        //}

        //private void EnviarOrdemAoABS(string drinkType,string drinkFlavor, string drinkSize, string orderType,string cupType, int iceAmount, string coverType)
        //{ 
        //    Console.WriteLine($"A bebida selecionada {drinkType} {drinkFlavor}, foi servida em: Copo de {cupType}, Contendo: {iceAmount} pedras de gelo, com {drinkSize}ml, e {coverType}");
        //}
    }
}
