﻿
using TODO.Net.Clients;

// REST
var restClient = new TODORestClient();
var ticker = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
Console.WriteLine($"Rest client ticker price for ETHUSDT: {ticker.Data.List.First().LastPrice}");

Console.WriteLine();
Console.WriteLine("Press enter to start websocket subscription");
Console.ReadLine();

// Websocket
var socketClient = new TODOSocketClient();
var subscription = await socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", update =>
{
    Console.WriteLine($"Websocket client ticker price for ETHUSDT: {update.Data.LastPrice}");
});

Console.ReadLine();
