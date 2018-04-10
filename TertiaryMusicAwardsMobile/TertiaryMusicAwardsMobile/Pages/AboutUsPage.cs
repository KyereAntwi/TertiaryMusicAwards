using System;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.Pages
{
    public class AboutUsPage : ContentPage
	{
		public AboutUsPage ()
		{
			Content = new ScrollView {
                Content = 
                    new StackLayout
                    {
                        Children =
                        {
                            new Image
                    {
                        HeightRequest = 140,
                        WidthRequest = 140,
                        HorizontalOptions = LayoutOptions.Center,
                        Aspect = Aspect.Fill,
                        Source = ImageSource.FromFile("image.jpg")
                    },

                    new Label
                    {
                        Text = "Tertiary Music Awards " + DateTime.Now.Year,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 20,
                        TextColor = Color.Black
                    },

                     new Label
                    {
                        Text = "ABOUT US",
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Color.Black
                    },

                      new Label
                    {
                        Text = "Tertiary Music Awards-Gh (styled as TERMA-gh) is presented by Tomorrows Leaders Incorporation " +
                        "to recognize the talent/achievements of tertiary students in the music industry. " +
                        "The annual presentation ceremony shares recognition of tertiary institutions as other prominent " +
                        "awards such as UMB Ghana Tertiary Awards, National Students Award and Face of Tertiary. " +
                        "We are here to brighten young stars for the world’s recognition through music. ",

                        Margin = 5,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Color.FromHex("#ddd")
                    },

                       new Label
                    {
                        Text = "VISION",
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Color.Black
                    },

                        new Label
                    {
                        Text = "To be the leading discoverer of talent in upcoming musicians",

                        Margin = 5,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Color.FromHex("#ddd")
                    },

                         new Label
                    {
                        Text = "HISTORY",
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Color.Black
                    },

                           new Label
                            {
                                Text = "The decision to embark on this project was borne from the fact that talented upcoming " +
                                "artistes in tertiary institutions are not recognized due to insufficient funding to support " +
                                "and to promote their songs.  The executives decided to rectify this by creating an award " +
                                "to honor these upcoming tertiary artistes. The first Tertiary Music Awards was held at Changes " +
                                "Pub and Grills formerly known as Bella Roma, Osu on October 6, 2017 to honor the musical " +
                                "achievement of tertiary artistes for 2017. On September 16, 2017 at Tenko Plaza, East Legon " +
                                "the Nominees Jam was held, which recorded many audience at the show." +
                                "The maiden edition had about 150 nominations from 20 tertiary institutions, involving 60 " +
                                "nominated tertiary artistes. It was a spectacular event which has now become one of " +
                                "the most prestigious award events for tertiary students",

                                Margin = 5,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontAttributes = FontAttributes.Bold,
                                FontSize = 18,
                                TextColor = Color.FromHex("#ddd")
                            },

                           new Label
                           {
                               Text = "ENTRY PROCESS AND SELECTION OF NOMINEES",
                               HorizontalTextAlignment = TextAlignment.Center,
                               FontAttributes = FontAttributes.Bold,
                               FontSize = 18,
                               TextColor = Color.Black
                           },

                           new Label
                            {

                                Text = "Artistes must be admitted to any tertiary Institution registered with the National " +
                                "Accreditation Board. Entries are made online and a physical copy of work is sent to " +
                                "the organizing company.Once an application is submitted, investigations are made to " +
                                "determine whether the information is entered in the right category.",

                                Margin = 5,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontAttributes = FontAttributes.Bold,
                                FontSize = 18,
                                TextColor = Color.FromHex("#ddd")
                            },

                           new Label
                           {
                               Text = "CONTACT US",
                               HorizontalTextAlignment = TextAlignment.Center,
                               FontAttributes = FontAttributes.Bold,
                               FontSize = 18,
                               TextColor = Color.Black
                           },

                           new Label
                            {

                                Text = "Email: tertiarymusicawards2018@gmail.com \n" +
                                        "Mobile: +233 (0) /266861185/241768889/501206887/267621483 \n" +
                                        "Social Media Handle \n" +
                                        "Instagram: Termagh1 \n" +
                                        "Twitter: @termagh1 \n" +
                                        "Facebook: Tertiarymusicaward \n",
                                Margin = 5,
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontAttributes = FontAttributes.Bold,
                                FontSize = 18,
                                TextColor = Color.FromHex("#ddd")
                            },
                        }
                    }
			};
		}
	}
}