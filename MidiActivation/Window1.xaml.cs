using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MidiActivation
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		// *******************************************************************
		private void calculate_button_Click(object sender, RoutedEventArgs e)
		{
			const uint CONST_CODE = 0x005B0000;
			const uint PLUS_VALUE = 0x00131415;
			const uint XOR_VALUE = 0x96A357BC;

			uint act_code;
			uint tempU32;
			uint serial;
			byte move;

			try
			{
				tempU32 = (uint)Convert.ToInt32(serial_number.Text);

				if (tempU32 > 9999)
				{
					MessageBox.Show("Nieprawidłowy format numeru seryjnego", "Informacja");
					activation_value.Text = "";
				}
				else
				{
					act_code = (uint)tempU32;
					serial = act_code;
					act_code |= CONST_CODE;
					act_code += PLUS_VALUE;
					act_code ^= XOR_VALUE;
					move = (byte)(serial & 0x07);			// 3 bity
					tempU32 = act_code << move;
					move = (byte)(32 - move);
					tempU32 |= (act_code >> move);

					act_code = tempU32;

					activation_value.Text = act_code.ToString();
				}
			}
			catch
			{
				MessageBox.Show("Nieprawidłowy format numeru seryjnego", "Informacja");
				activation_value.Text = "";
			}



		}	// calculate_button_Click

	}
}
