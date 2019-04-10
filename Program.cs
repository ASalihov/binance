using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BinanceExchange.API;
using BinanceExchange.API.Client;
using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Enums;
using BinanceExchange.API.Market;
using BinanceExchange.API.Models.Request;
using BinanceExchange.API.Models.Response;
using BinanceExchange.API.Models.Response.Error;
using BinanceExchange.API.Models.WebSocket;
using BinanceExchange.API.Utility;
using BinanceExchange.API.Websockets;
using log4net;
using Newtonsoft.Json;
using WebSocketSharp;
using Binance.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Binance.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            string apiKey = configuration["Appsettings:apiKey"];
            string secretKey = configuration["Appsettings:secretKey"];

            var exampleProgramLogger = LogManager.GetLogger(typeof(Program));

            var client = new BinanceClient(new ClientConfiguration()
            {
                ApiKey = apiKey,
                SecretKey = secretKey,
                Logger = exampleProgramLogger,
            });

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            exampleProgramLogger.Debug("Logging Test");
            var userData = await client.StartUserDataStream();
            await client.KeepAliveUserDataStream(userData.ListenKey);
            Start(client, token);
            System.Console.WriteLine("Press any key to stop writing trades into DB");
            System.Console.Read();
            tokenSource.Cancel();
            await client.CloseUserDataStream(userData.ListenKey);
            System.Console.WriteLine("The End");
        }

        private static async Task Start(BinanceClient client, CancellationToken token)
        {
            await Task.Factory.StartNew(() =>
            {

                token.ThrowIfCancellationRequested();
                using (var context = new BinanceContext())
                using (var binanceWebSocketClient = new DisposableBinanceWebSocketClient(client))
                {
                    binanceWebSocketClient.ConnectToTradesWebSocket("BNBBTC", data =>
                    {
                        var tradeDate = new TradeData
                        {
                            e = data.EventType,
                            E = data.EventTime,
                            s = data.Symbol,
                            a = data.AggregateTradeId,
                            p = data.Price,
                            q = data.Quantity,
                            f = data.FirstTradeId,
                            l = data.LastTradeId,
                            T = data.TradeTime,
                            m = data.WasBuyerMaker
                        };
                        context.TradeDatas.Add(tradeDate);
                        context.SaveChanges();
                            //System.Console.WriteLine($"KlineCall: {JsonConvert.SerializeObject(data)}");
                        });

                    while (!token.IsCancellationRequested)
                    {
                    }
                }
            }, token);
        }
    }
}