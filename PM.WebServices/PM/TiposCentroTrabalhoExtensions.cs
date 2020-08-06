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
    /// Extension methods for TiposCentroTrabalho.
    /// </summary>
    public static partial class TiposCentroTrabalhoExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static TipoCentroTrabalho GetById(this ITiposCentroTrabalho operations, int id)
            {
                return Task.Factory.StartNew(s => ((ITiposCentroTrabalho)s).GetByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TipoCentroTrabalho> GetByIdAsync(this ITiposCentroTrabalho operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<TipoCentroTrabalho> GetAll(this ITiposCentroTrabalho operations)
            {
                return Task.Factory.StartNew(s => ((ITiposCentroTrabalho)s).GetAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<TipoCentroTrabalho>> GetAllAsync(this ITiposCentroTrabalho operations, CancellationToken cancellationToken = default(CancellationToken))
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
            public static TipoCentroTrabalho Add(this ITiposCentroTrabalho operations, TipoCentroTrabalho obj)
            {
                return Task.Factory.StartNew(s => ((ITiposCentroTrabalho)s).AddAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TipoCentroTrabalho> AddAsync(this ITiposCentroTrabalho operations, TipoCentroTrabalho obj, CancellationToken cancellationToken = default(CancellationToken))
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
            public static TipoCentroTrabalho Update(this ITiposCentroTrabalho operations, TipoCentroTrabalho obj)
            {
                return Task.Factory.StartNew(s => ((ITiposCentroTrabalho)s).UpdateAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TipoCentroTrabalho> UpdateAsync(this ITiposCentroTrabalho operations, TipoCentroTrabalho obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='tipoCentroTrabalho'>
            /// </param>
            public static TipoCentroTrabalho Delete(this ITiposCentroTrabalho operations, TipoCentroTrabalho tipoCentroTrabalho)
            {
                return Task.Factory.StartNew(s => ((ITiposCentroTrabalho)s).DeleteAsync(tipoCentroTrabalho), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='tipoCentroTrabalho'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TipoCentroTrabalho> DeleteAsync(this ITiposCentroTrabalho operations, TipoCentroTrabalho tipoCentroTrabalho, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(tipoCentroTrabalho, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}