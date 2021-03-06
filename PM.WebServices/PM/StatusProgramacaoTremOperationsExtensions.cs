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
    /// Extension methods for StatusProgramacaoTremOperations.
    /// </summary>
    public static partial class StatusProgramacaoTremOperationsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static StatusProgramacaoTrem GetById(this IStatusProgramacaoTremOperations operations, int id)
            {
                return Task.Factory.StartNew(s => ((IStatusProgramacaoTremOperations)s).GetByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusProgramacaoTrem> GetByIdAsync(this IStatusProgramacaoTremOperations operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<StatusProgramacaoTrem> GetAll(this IStatusProgramacaoTremOperations operations)
            {
                return Task.Factory.StartNew(s => ((IStatusProgramacaoTremOperations)s).GetAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<StatusProgramacaoTrem>> GetAllAsync(this IStatusProgramacaoTremOperations operations, CancellationToken cancellationToken = default(CancellationToken))
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
            public static StatusProgramacaoTrem Add(this IStatusProgramacaoTremOperations operations, StatusProgramacaoTrem obj)
            {
                return Task.Factory.StartNew(s => ((IStatusProgramacaoTremOperations)s).AddAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusProgramacaoTrem> AddAsync(this IStatusProgramacaoTremOperations operations, StatusProgramacaoTrem obj, CancellationToken cancellationToken = default(CancellationToken))
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
            public static StatusProgramacaoTrem Update(this IStatusProgramacaoTremOperations operations, StatusProgramacaoTrem obj)
            {
                return Task.Factory.StartNew(s => ((IStatusProgramacaoTremOperations)s).UpdateAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusProgramacaoTrem> UpdateAsync(this IStatusProgramacaoTremOperations operations, StatusProgramacaoTrem obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static StatusProgramacaoTrem Delete(this IStatusProgramacaoTremOperations operations, StatusProgramacaoTrem obj)
            {
                return Task.Factory.StartNew(s => ((IStatusProgramacaoTremOperations)s).DeleteAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusProgramacaoTrem> DeleteAsync(this IStatusProgramacaoTremOperations operations, StatusProgramacaoTrem obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cd'>
            /// </param>
            public static StatusProgramacaoTrem GetByCdSap(this IStatusProgramacaoTremOperations operations, string cd)
            {
                return Task.Factory.StartNew(s => ((IStatusProgramacaoTremOperations)s).GetByCdSapAsync(cd), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cd'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StatusProgramacaoTrem> GetByCdSapAsync(this IStatusProgramacaoTremOperations operations, string cd, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByCdSapWithHttpMessagesAsync(cd, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
