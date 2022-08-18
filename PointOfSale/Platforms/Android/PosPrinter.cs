using Android.Bluetooth;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Services
{
    public partial class PosPrinter
    {
        public async partial Task Print(string contract, string product, string partnumber)
        {
            string printerName = "BlueTooth Printer";
            using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
            {
                if (bluetoothAdapter == null)
                {
                    throw new Exception("No default adapter");
                    //return;
                }

                if (!bluetoothAdapter.IsEnabled)
                {
                    throw new Exception("Bluetooth not enabled");
                    //Intent enableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                    //StartActivityForResult(enableIntent, REQUEST_ENABLE_BT);
                    // Otherwise, setup the chat session
                }

                BluetoothDevice device = (from bd in bluetoothAdapter.BondedDevices
                                          where bd.Name == printerName
                                          select bd).FirstOrDefault();
                if (device == null)
                {
                    throw new Exception(printerName + " device not found.");
                }
                    

                try
                {
                    using (BluetoothSocket _socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb")))
                    {
                        await _socket.ConnectAsync();


                        Helpers.PosPrint printerHelper = new Helpers.PosPrint();

                        // Write data to the device
                        contract = "AX0111.NETMAUI";
                        product = "Test 1";
                        partnumber = "001";
                        await _socket.OutputStream.WriteAsync(printerHelper.Print(contract, product, partnumber), 0, printerHelper.Print(contract, product, partnumber).Length);

                        _socket.Close();
                    }
                }
                catch (Exception exp)
                {

                    throw exp;
                }


            }

        }

        public async partial Task PrintPlacedOrder()
        {
            string printerName = "BlueTooth Printer";
            using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
            {
                if (bluetoothAdapter == null)
                {
                    throw new Exception("No default adapter");
                    //return;
                }

                if (!bluetoothAdapter.IsEnabled)
                {
                    throw new Exception("Bluetooth not enabled");
                    //Intent enableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                    //StartActivityForResult(enableIntent, REQUEST_ENABLE_BT);
                    // Otherwise, setup the chat session
                }

                BluetoothDevice device = (from bd in bluetoothAdapter.BondedDevices
                                          where bd.Name == printerName
                                          select bd).FirstOrDefault();
                if (device == null)
                {
                    throw new Exception(printerName + " device not found.");
                }


                try
                {
                    using (BluetoothSocket _socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb")))
                    {
                        await _socket.ConnectAsync();


                        Helpers.PosPrint printerHelper = new Helpers.PosPrint();

                        // Write data to the device
                       
                        await _socket.OutputStream.WriteAsync(printerHelper.PrintOrder(), 0, printerHelper.PrintOrder().Length);

                        _socket.Close();
                    }
                }
                catch (Exception exp)
                {

                    throw exp;
                }


            }

        }

    }
}
