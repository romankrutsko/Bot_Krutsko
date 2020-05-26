using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using ApiBotTelegram.Model;
using Exceptionless.Models.Data;

namespace ApiBotTelegram
{
    class Program
    {
        static TelegramBotClient Bot;
        private static string buttonText;

        static void Main(string[] args)
        {
            Bot = new TelegramBotClient("1144813972:AAF10Q8bz8Gy9b0UPqW0tjWz2Wytu95SmX0");

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
            
        }

        private static void BotOnCallbackQueryReceived(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            buttonText = e.CallbackQuery.Data;
            
        }

        private static async void BotOnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var client = new HttpClient();
            var message = e.Message;
            
            if (message == null || message.Type != MessageType.Text)
                return;
            string name = $"{message.From.FirstName} {message.From.LastName}";
            Console.WriteLine($"{name} { message.Text}");

            switch(message.Text)
            {
                case "/start":
                    string text =
@"Список команд:
/start - запуск бота
/inline - меню
/keyboard - клавіатура";
                    await Bot.SendTextMessageAsync(message.From.Id, text);
                    break;

                

                case "/gettopscorer":
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("0"),
                            InlineKeyboardButton.WithCallbackData("1"),
                            InlineKeyboardButton.WithCallbackData("2"),
                            InlineKeyboardButton.WithCallbackData("3"),
                            InlineKeyboardButton.WithCallbackData("4")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("5"),
                            InlineKeyboardButton.WithCallbackData("6"),
                            InlineKeyboardButton.WithCallbackData("7"),
                            InlineKeyboardButton.WithCallbackData("8"),
                            InlineKeyboardButton.WithCallbackData("9")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("10"),
                            InlineKeyboardButton.WithCallbackData("11"),
                            InlineKeyboardButton.WithCallbackData("12"),
                            InlineKeyboardButton.WithCallbackData("13"),
                            InlineKeyboardButton.WithCallbackData("14")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("15"),
                            InlineKeyboardButton.WithCallbackData("16"),
                            InlineKeyboardButton.WithCallbackData("17"),
                            InlineKeyboardButton.WithCallbackData("18"),
                            InlineKeyboardButton.WithCallbackData("19")
                        }
                    }); 
                    await Bot.SendTextMessageAsync(message.From.Id, "Виберіть номер футболіста 0 - 19 ", replyMarkup: inlineKeyboard);
                    string data = buttonText;
                    //await Bot.SendTextMessageAsync(message.From.Id, $"{data}");

                    //var message1 = message;
                    //message = Convert.ToString(e.Message);


                    /*var request5.numberNote = Convert.ToInt32(message.Text)*/
                    ;
                        //await Bot.SendTextMessageAsync(message.From.Id, $"{m}");
                        
                        //await Bot.SendTextMessageAsync(message.From.Id, $"{data}");
                        
                    
                    var content = await client.GetStringAsync($"https://localhost:44344/api/sportinfo/data");
                    TopScorers topScorers = JsonConvert.DeserializeObject<TopScorers>(content);
                    await Bot.SendTextMessageAsync(message.From.Id, $"Ім’я: {topScorers.firstname}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Призвище: {topScorers.lastname}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Національність: {topScorers.nationality}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Загальний час на полі: {topScorers.games.minutes_played}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Кількість голів: {topScorers.goals.total}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Кількість ударів: {topScorers.shots.total}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Кількість ударів в площину воріт: {topScorers.shots.on}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Кількість асистів: {topScorers.goals.assists}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Кількість жовтих карток: {topScorers.cards.yellow}");
                    await Bot.SendTextMessageAsync(message.From.Id, $"Кількість червоних карток: {topScorers.cards.red}");

                    break;

                default:
                    break;
            }
        }
    }
}
