﻿using BingX.Net.Enums;
using BingX.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BingX.Net.Interfaces.Clients.PerpetualFuturesApi
{
    /// <summary>
    /// BingX futures trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IBingXRestClientPerpetualFuturesApiTrading
    {
        /// <summary>
        /// Get positions
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/account-api.html#Perpetual%20Swap%20Positions" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BingXPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new test order. Order won't actually get placed
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Trade%20order%20test" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Limit price</param>
        /// <param name="positionSide">Position side</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="stopPrice">Stop price</param>
        /// <param name="priceRate">Trailing percentage (between 0 and 1)</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="closePosition">Close the position</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="stopGuaranteed">Stop guaranteed</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXFuturesOrder>> PlaceTestOrderAsync(
            string symbol,
            OrderSide side,
            FuturesOrderType type,
            PositionSide positionSide,
            decimal? quantity = null,
            decimal? price = null,
            bool? reduceOnly = null,
            decimal? stopPrice = null,
            decimal? priceRate = null,

            //TakeProfitStopLossMode? stopLossType = null,
            //decimal? stopLossStopPrice = null,
            //decimal? stopLossPrice = null,
            //TriggerType? stopLossTriggerType = null,
            //bool? stopLossStopGuaranteed = null,

            //TakeProfitStopLossMode? takeProfitType = null,
            //decimal? takeProfitStopPrice = null,
            //decimal? takeProfitPrice = null,
            //TriggerType? takeProfitTriggerType = null,
            //bool? takeProfitStopGuaranteed = null,

            TimeInForce? timeInForce = null,
            bool? closePosition = null,
            decimal? triggerPrice = null,
            bool? stopGuaranteed = null,
            string? clientOrderId = null,
            CancellationToken ct = default);


        /// <summary>
        /// Place a new order
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Trade%20order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Limit price</param>
        /// <param name="positionSide">Position side</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="stopPrice">Stop price</param>
        /// <param name="priceRate">Trailing percentage (between 0 and 1)</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="closePosition">Close the position</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="stopGuaranteed">Stop guaranteed</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXFuturesOrder>> PlaceOrderAsync(
            string symbol,
            OrderSide side,
            FuturesOrderType type,
            PositionSide positionSide,
            decimal? quantity = null,
            decimal? price = null,
            bool? reduceOnly = null,
            decimal? stopPrice = null,
            decimal? priceRate = null,

            //TakeProfitStopLossMode? stopLossType = null,
            //decimal? stopLossStopPrice = null,
            //decimal? stopLossPrice = null,
            //TriggerType? stopLossTriggerType = null,
            //bool? stopLossStopGuaranteed = null,

            //TakeProfitStopLossMode? takeProfitType = null,
            //decimal? takeProfitStopPrice = null,
            //decimal? takeProfitPrice = null,
            //TriggerType? takeProfitTriggerType = null,
            //bool? takeProfitStopGuaranteed = null,

            TimeInForce? timeInForce = null,
            bool? closePosition = null,
            decimal? triggerPrice = null,
            bool? stopGuaranteed = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple new orders in one go
        /// </summary>
        /// <param name="orders">Orders to place</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BingXFuturesOrder>>> PlaceMultipleOrderAsync(
            IEnumerable<BingXFuturesPlaceOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Get an order
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Query%20Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXFuturesOrderDetails>> GetOrderAsync(string symbol, long? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Cancel%20an%20Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXFuturesOrderDetails>> CancelOrderAsync(string symbol, long? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Close all positions. Positions will be closed via market order
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#One-Click%20Close%20All%20Positions" /></para>
        /// </summary>
        /// <param name="symbol">Only close for a specific symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXClosePositionsResult>> CloseAllPositionsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders on a symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="orderIds">The ids of orders to cancel</param>
        /// <param name="clientOrderIds">The client order ids of orders to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXCancelAllResult>> CancelMultipleOrderAsync(string symbol, IEnumerable<long>? orderIds, IEnumerable<string>? clientOrderIds = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all open orders
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Cancel%20All%20Orders" /></para>
        /// </summary>
        /// <param name="symbol">Only cancel orders for this symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXCancelAllResult>> CancelAllOrderAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get all open orders
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Query%20all%20current%20pending%20orders" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BingXFuturesOrderDetails>>> GetOpenOrdersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get liquidation order history
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#User's%20Force%20Orders" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="closeType">Filter by close type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BingXFuturesOrderDetails>>> GetLiquidationOrdersAsync(string? symbol = null, AutoCloseType? closeType = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed orders
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#User's%20History%20Orders" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BingXFuturesOrderDetails>>> GetClosedOrderAsync(string? symbol = null, long? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trade history
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#User's%20History%20Orders" /></para>
        /// </summary>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BingXFuturesUserTrade>>> GetUserTradesAsync(long? orderId = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all order after a set period. Can be called contineously to maintain a rolling timeout
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Cancel%20all%20orders%20in%20countdown" /></para>
        /// </summary>
        /// <param name="activate">True to activate the trigger, false to disable the trigger</param>
        /// <param name="cancelAfterSeconds">Seconds after which to cancel all orders, between 10 and 120</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXCancelAfterResult>> CancelAllOrdersAfterAsync(bool activate, int cancelAfterSeconds, CancellationToken ct = default);

        /// <summary>
        /// Close a position by its id
        /// <para><a href="https://bingx-api.github.io/docs/#/en-us/swapV2/trade-api.html#Close%20the%20position%20by%20position%20ID" /></para>
        /// </summary>
        /// <param name="positionId">The id of the position to close</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BingXClosePositionResult>> ClosePositionAsync(string positionId, CancellationToken ct = default);
    }
}
