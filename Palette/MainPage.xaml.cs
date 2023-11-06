using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Palette
{
	public partial class MainPage : ContentPage
	{
		//Global attributes
		private Color color = new Color();
		private Random random = new Random();
		private bool IsRandom = false;

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
            if (!IsRandom)
            {
				var Red = SldRed.Value;
				var Green = SldGreen.Value;
				var Blue = SldBlue.Value;
				var Alpha = SldTransparency.Value;

				color = Color.FromRgba(Red, Green, Blue, Alpha);

				SetColor(color);
			}
        }

		private void SetColor(Color color)
		{
			TxtRed.Text = color.R.ToString();
			TxtGreen.Text = color.G.ToString();
			TxtBlue.Text = color.B.ToString();
			TxtTransparency.Text = color.A.ToString();

			Container.BackgroundColor = color;
			LblTitle.TextColor = color;
			LblHex.TextColor = color;
			LblHex.Text = "Hex value: " + color.ToHex();
		}

		private void Random_Clicked(object sender, EventArgs e)
		{
			IsRandom = true;

            color = Color.FromRgba(
				random.Next(0, 256),
				random.Next(0, 256),
				random.Next(0, 256),
				random.Next(0,255));

			SetColor(color);

			SldRed.Value = color.R;
			SldGreen.Value = color.G;
			SldBlue.Value = color.B;
			SldTransparency.Value = color.A;

			IsRandom = false;
		}
	}
}
