using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
