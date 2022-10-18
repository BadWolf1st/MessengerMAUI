﻿using Microsoft.Maui.LifecycleEvents;

namespace MessengerMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		PagesChanger();
    }

	public void PagesChanger(string NamePage = "LogInPage")
	{
		if(NamePage == "LogInPage")
		{
			MainPage = new LogInPage();
		}
		else if(NamePage == "MainPage")
		{
			MainPage = new MainPage();
		}
	}
}
