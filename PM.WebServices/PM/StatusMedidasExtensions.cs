﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace PM.WebServices
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for StatusMedidas.
    /// </summary>
    public static partial class StatusMedidasExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static StatusMedida GetById(this IStatusMedidas operations, int id)
            {
                return Task.Factory.StartNew(s => ((IStatusMedidas)s).GetByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusMedida> GetByIdAsync(this IStatusMedidas operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cdSap'>
            /// </param>
            public static StatusMedida GetByCdSap(this IStatusMedidas operations, string cdSap)
            {
                return Task.Factory.StartNew(s => ((IStatusMedidas)s).GetByCdSapAsync(cdSap), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cdSap'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusMedida> GetByCdSapAsync(this IStatusMedidas operations, string cdSap, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByCdSapWithHttpMessagesAsync(cdSap, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<StatusMedida> GetAll(this IStatusMedidas operations)
            {
                return Task.Factory.StartNew(s => ((IStatusMedidas)s).GetAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<StatusMedida>> GetAllAsync(this IStatusMedidas operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static StatusMedida Add(this IStatusMedidas operations, StatusMedida obj)
            {
                return Task.Factory.StartNew(s => ((IStatusMedidas)s).AddAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusMedida> AddAsync(this IStatusMedidas operations, StatusMedida obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.AddWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static StatusMedida Update(this IStatusMedidas operations, StatusMedida obj)
            {
                return Task.Factory.StartNew(s => ((IStatusMedidas)s).UpdateAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusMedida> UpdateAsync(this IStatusMedidas operations, StatusMedida obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='statusMedida'>
            /// </param>
            public static StatusMedida Delete(this IStatusMedidas operations, StatusMedida statusMedida)
            {
                return Task.Factory.StartNew(s => ((IStatusMedidas)s).DeleteAsync(statusMedida), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='statusMedida'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusMedida> DeleteAsync(this IStatusMedidas operations, StatusMedida statusMedida, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(statusMedida, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}