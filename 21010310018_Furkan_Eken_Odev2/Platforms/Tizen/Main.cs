using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace _21010310018_Furkan_Eken_Odev2;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
