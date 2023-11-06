using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Palette
{
	public partial class MainPage : ContentPage
	{
		//Global attributes
		private Color color;

		public MainPage()
		{
			InitializeComponent();

			//Initialize attributes
			SldTransparency.Value = 1;
			TxtRed.IsReadOnly = true;
			TxtGreen.IsReadOnly = true;
			TxtBlue.IsReadOnly = true;
			TxtTransparency.IsReadOnly = true;
		}

		private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			var Red = SldRed.Value;
			var Green = SldGreen.Value;
			var Blue = SldBlue.Value;
			var Alpha = SldTransparency.Value;

			color = Color.FromRgba(Red, Green, Blue, Alpha);

			TxtRed.Text = color.R.ToString();
			TxtGreen.Text = color.G.ToString();
			TxtBlue.Text = color.B.ToString();
			TxtTransparency.Text = color.A.ToString();

			SetColor(color);
		}

		private void SetColor(Color color)
		{
			Container.BackgroundColor = color;
			LblHex.TextColor = color;
			LblHex.Text = "Hex value: " + color.ToHex();
		}
	}
}
