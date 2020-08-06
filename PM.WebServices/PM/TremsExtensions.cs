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
    /// Extension methods for Trems.
    /// </summary>
    public static partial class TremsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static Trem GetById(this ITrems operations, int id)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).GetByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Trem> GetByIdAsync(this ITrems operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<Trem> GetAll(this ITrems operations)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).GetAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Trem>> GetAllAsync(this ITrems operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static IList<Trem> GetByFrota(this ITrems operations, int id)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).GetByFrotaAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Trem>> GetByFrotaAsync(this ITrems operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByFrotaWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='idLinha'>
            /// </param>
            /// <param name='idPatio'>
            /// </param>
            /// <param name='idStatus'>
            /// </param>
            /// <param name='manobra'>
            /// </param>
            public static IList<Trem> GetByPatioLinhaStatus(this ITrems operations, int idLinha, int idPatio, int idStatus, int manobra)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).GetByPatioLinhaStatusAsync(idLinha, idPatio, idStatus, manobra), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='idLinha'>
            /// </param>
            /// <param name='idPatio'>
            /// </param>
            /// <param name='idStatus'>
            /// </param>
            /// <param name='manobra'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Trem>> GetByPatioLinhaStatusAsync(this ITrems operations, int idLinha, int idPatio, int idStatus, int manobra, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByPatioLinhaStatusWithHttpMessagesAsync(idLinha, idPatio, idStatus, manobra, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='idLinha'>
            /// </param>
            /// <param name='idPatio'>
            /// </param>
            /// <param name='idTrem'>
            /// </param>
            public static IList<Trem> GetByLinhaPatioTrem(this ITrems operations, int idLinha, int idPatio, int idTrem)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).GetByLinhaPatioTremAsync(idLinha, idPatio, idTrem), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='idLinha'>
            /// </param>
            /// <param name='idPatio'>
            /// </param>
            /// <param name='idTrem'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Trem>> GetByLinhaPatioTremAsync(this ITrems operations, int idLinha, int idPatio, int idTrem, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByLinhaPatioTremWithHttpMessagesAsync(idLinha, idPatio, idTrem, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static Trem Add(this ITrems operations, Trem obj)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).AddAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Trem> AddAsync(this ITrems operations, Trem obj, CancellationToken cancellationToken = default(CancellationToken))
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
            public static Trem Update(this ITrems operations, Trem obj)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).UpdateAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Trem> UpdateAsync(this ITrems operations, Trem obj, CancellationToken cancellationToken = default(CancellationToken))
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
            public static Trem Delete(this ITrems operations, Trem obj)
            {
                return Task.Factory.StartNew(s => ((ITrems)s).DeleteAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Trem> DeleteAsync(this ITrems operations, Trem obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
