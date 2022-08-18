using PointOfSale.Pages.Handheld;
using PrinterUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Helpers
{
    public class PosPrint
    {
        public byte[] Print(string contractaddress, string product, string partnomber)
        {
            DateTime now = DateTime.Now;
            byte[] br = new byte[0];
            string ESC = Convert.ToString((char)27);
            string bold_on = ESC + "E" + (char)1; //turn on bold mode

            string bold_off = ESC + "E" + (char)0; //turn off bold mode

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            OrderDetailsViewModel receipt = new OrderDetailsViewModel();
            OrdersViewModel ordersViewModel = new OrdersViewModel();
            br = PrintExtensions.AddBytes(br, obj.CharSize.Nomarl());
            br = PrintExtensions.AddBytes(br, obj.FontSelect.FontA());
            br = PrintExtensions.AddBytes(br, obj.Alignment.Center());
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Point of sale .NET MAUI" + "\n"));
            br = PrintExtensions.AddBytes(br, obj.CharSize.Nomarl());
            br = PrintExtensions.AddBytes(br, obj.FontSelect.FontC());
            br = PrintExtensions.AddBytes(br, obj.Alignment.Left());
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Date:" + now.ToString("MM-dd-yyyy h:mm tt") + "\n"));
           
            string table = App.order.Table.ToString();
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Table: " + table + "\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(string.Format("{0,-20}{1,10}\n", "Item", "Price")));
            br = PrintExtensions.AddBytes(br, string.Format("{0,-20}{1,10}\n", "--------------------", "----------"));
            int DescriptionSize = 20;
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_on));

            foreach (Item item in App.order.Items)
            {


                br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(ItemFormat(item.Title, item.Price, DescriptionSize)));

            }

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_off));

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            string paga = string.Format("{0:C2}", App.order.Items.Sum(x => x.SubTotal));
            double tax = App.order.Items.Sum(x=> x.SubTotal) * 0.0825;
            double total = App.order.Items.Sum(x => x.SubTotal) + tax;
            string taxs = string.Format("{0:C2}",tax);
            string totals = string.Format("{0:C2}", total);
            br = PrintExtensions.AddBytes(br, obj.Alignment.Right());
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Subtotal " + paga + "\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Tax " + taxs + "\n"));
            br = PrintExtensions.AddBytes(br, obj.CharSize.DoubleHeight2());
            br = PrintExtensions.AddBytes(br, obj.CharSize.DoubleWidth2());
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_on));

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Total " + totals+ "\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_off));

            br = PrintExtensions.AddBytes(br, obj.CharSize.Nomarl());
           
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
           
            br = PrintExtensions.AddBytes(br, obj.Alignment.Center());
            br = PrintExtensions.AddBytes(br, obj.BarCode.Code39("123"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(GetBarcodeStr("123", contractaddress)));
            //br = PrintExtensions.AddBytes(br, obj.QrCode.Print("1233", PrinterUtility.Enums.QrCodeSize.Medio));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(GetQRCode()));

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            
            
            return br;
        }

        public byte[] PrintOrder()
        {
            DateTime now = DateTime.Now;
            byte[] br = new byte[0];
            string ESC = Convert.ToString((char)27);
            string bold_on = ESC + "E" + (char)1; //turn on bold mode

            string bold_off = ESC + "E" + (char)0; //turn off bold mode

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            OrderDetailsViewModel receipt = new OrderDetailsViewModel();
            OrdersViewModel ordersViewModel = new OrdersViewModel();
            br = PrintExtensions.AddBytes(br, obj.CharSize.Nomarl());
            br = PrintExtensions.AddBytes(br, obj.FontSelect.FontA());
            br = PrintExtensions.AddBytes(br, obj.Alignment.Center());
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Point of sale .NET MAUI" + "\n"));
            br = PrintExtensions.AddBytes(br, obj.CharSize.Nomarl());
            br = PrintExtensions.AddBytes(br, obj.FontSelect.FontC());
            br = PrintExtensions.AddBytes(br, obj.Alignment.Left());
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Date:" + now.ToString("MM-dd-yyyy h:mm tt") + "\n"));

            //string table = App.order.Table.ToString();
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Order #4773" + "\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Status: Placed order" + "\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(string.Format("{0,-20}{1,10}\n", "Item", "QTY")));
            br = PrintExtensions.AddBytes(br, string.Format("{0,-20}{1,10}\n", "--------------------", "----------"));
            int DescriptionSize = 20;
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_on));

            foreach (Item item in App.order.Items)
            {

                if(item.Category != ItemCategory.Beverages)
                {
                    br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(ItemFormatQ(item.Title, item.Quantity, DescriptionSize)));
                }
                

            }

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_off));

            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            //string paga = string.Format("{0:C2}", App.order.Items.Sum(x => x.SubTotal));
            //double tax = App.order.Items.Sum(x => x.SubTotal) * 0.0825;
            //double total = App.order.Items.Sum(x => x.SubTotal) + tax;
            //string taxs = string.Format("{0:C2}", tax);
            //string totals = string.Format("{0:C2}", total);
            //br = PrintExtensions.AddBytes(br, obj.Alignment.Right());
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Subtotal " + paga + "\n"));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Tax " + taxs + "\n"));
            //br = PrintExtensions.AddBytes(br, obj.CharSize.DoubleHeight2());
            //br = PrintExtensions.AddBytes(br, obj.CharSize.DoubleWidth2());
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_on));

            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("Total " + totals + "\n"));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(bold_off));

            br = PrintExtensions.AddBytes(br, obj.CharSize.Nomarl());

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));

            br = PrintExtensions.AddBytes(br, obj.Alignment.Center());
            br = PrintExtensions.AddBytes(br, obj.BarCode.Code39("4773"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(GetBarcodeStr("123", contractaddress)));
            //br = PrintExtensions.AddBytes(br, obj.QrCode.Print("1233", PrinterUtility.Enums.QrCodeSize.Medio));
            //br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes(GetQRCode()));

            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));
            br = PrintExtensions.AddBytes(br, Encoding.ASCII.GetBytes("\n"));


            return br;
        }

        public static string getStrSplit(string x, int length)
        {

            string result = string.Empty;
            if (x.Length <= length)
            {
                return x;
            }
            else
            {
                var sub = x.Substring(0, length);
                result += sub + "\n" + getStrSplit(x.Replace(sub, ""), length);
            }

            return result;
        }
        public static string ItemFormat(string item, double price, int length)
        {

            var outStr = getStrSplit(item, length);
            var outlst = outStr.Split('\n').ToList();
            string output = string.Empty;
            output += string.Format("{0,-" + length.ToString() + "}{1,10:C}\n", outlst[0], price);
            if (outlst.Count > 1)
            {
                foreach (var i in outlst.Skip(1))
                {
                    output += string.Format("{0,-" + length.ToString() + "}\n", i);
                }
            }
            return output;
        }

        public static string ItemFormatQ(string item, int quantity, int length)
        {

            var outStr = getStrSplit(item, length);
            var outlst = outStr.Split('\n').ToList();
            string output = string.Empty;
            output += string.Format("{0,-" + length.ToString() + "}{1,10:N}\n", outlst[0], quantity);
            if (outlst.Count > 1)
            {
                foreach (var i in outlst.Skip(1))
                {
                    output += string.Format("{0,-" + length.ToString() + "}\n", i);
                }
            }
            return output;
        }
    }
}
