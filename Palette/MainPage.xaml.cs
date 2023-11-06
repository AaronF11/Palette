using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.Toasts;

namespace Palette
{
	public partial class MainPage : ContentPage
	{
		//Global attributes
		private Color Color = new Color();
		private Random Random = new Random();
		private bool IsRandom = false;
		private string HexValue { set; get; }

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

				Color = Color.FromRgba(Red, Green, Blue, Alpha);

				SetColor(Color);
			}
		}

		private void SetColor(Color Color)
		{
			TxtRed.Text = Color.R.ToString();
			TxtGreen.Text = Color.G.ToString();
			TxtBlue.Text = Color.B.ToString();
			TxtTransparency.Text = Color.A.ToString();

			Container.BackgroundColor = Color;
			LblTitle.TextColor = Color;
			LblHex.TextColor = Color;
			LblHex.Text = "Hex value: " + Color.ToHex();
			HexValue = Color.ToHex();
		}

		private void Random_Clicked(object sender, EventArgs e)
		{
			IsRandom = true;

			Color = Color.FromRgba(
				Random.Next(0, 256),
				Random.Next(0, 256),
				Random.Next(0, 256),
				Random.Next(0, 255));

			SetColor(Color);

			SldRed.Value = Color.R;
			SldGreen.Value = Color.G;
			SldBlue.Value = Color.B;
			SldTransparency.Value = Color.A;

			IsRandom = false;
		}

		private async void Copy_Clicked(object sender, EventArgs e)
		{
			await Clipboard.SetTextAsync(HexValue);
			var notificator = DependencyService.Get<IToastNotificator>();
			var options = new NotificationOptions()
			{
				Title = "Hex Value Copied",
				Description = "The hex value " + HexValue + " has been copied to clipboard."
			};

			var result = await notificator.Notify(options);
		}

	}
}
