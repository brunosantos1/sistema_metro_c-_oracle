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
    /// Extension methods for ProgramacaoOperations.
    /// </summary>
    public static partial class ProgramacaoOperationsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static Programacao GetById(this IProgramacaoOperations operations, int id)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).GetByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> GetByIdAsync(this IProgramacaoOperations operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<Programacao> GetAll(this IProgramacaoOperations operations)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).GetAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Programacao>> GetAllAsync(this IProgramacaoOperations operations, CancellationToken cancellationToken = default(CancellationToken))
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
            public static Programacao GetNavigationPropertiesByID(this IProgramacaoOperations operations, int id)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).GetNavigationPropertiesByIDAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> GetNavigationPropertiesByIDAsync(this IProgramacaoOperations operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNavigationPropertiesByIDWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
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
            /// <param name='idMotivo'>
            /// </param>
            /// <param name='dtInicio'>
            /// </param>
            /// <param name='dtFinal'>
            /// </param>
            public static IList<Programacao> GetByProgramacao(this IProgramacaoOperations operations, int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).GetByProgramacaoAsync(idLinha, idPatio, idTrem, idMotivo, dtInicio, dtFinal), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            /// <param name='idMotivo'>
            /// </param>
            /// <param name='dtInicio'>
            /// </param>
            /// <param name='dtFinal'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Programacao>> GetByProgramacaoAsync(this IProgramacaoOperations operations, int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByProgramacaoWithHttpMessagesAsync(idLinha, idPatio, idTrem, idMotivo, dtInicio, dtFinal, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static Programacao Add(this IProgramacaoOperations operations, Programacao obj)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).AddAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> AddAsync(this IProgramacaoOperations operations, Programacao obj, CancellationToken cancellationToken = default(CancellationToken))
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
            public static Programacao Update(this IProgramacaoOperations operations, Programacao obj)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).UpdateAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> UpdateAsync(this IProgramacaoOperations operations, Programacao obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static Programacao DeleteById(this IProgramacaoOperations operations, int id)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).DeleteByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> DeleteByIdAsync(this IProgramacaoOperations operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static Programacao LiberarProgramacao(this IProgramacaoOperations operations, Programacao obj)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).LiberarProgramacaoAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> LiberarProgramacaoAsync(this IProgramacaoOperations operations, Programacao obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.LiberarProgramacaoWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static Programacao CancelaProgramacao(this IProgramacaoOperations operations, Programacao obj)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).CancelaProgramacaoAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> CancelaProgramacaoAsync(this IProgramacaoOperations operations, Programacao obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CancelaProgramacaoWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            public static Programacao MudarLocalProgramacao(this IProgramacaoOperations operations, Programacao obj)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).MudarLocalProgramacaoAsync(obj), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='obj'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Programacao> MudarLocalProgramacaoAsync(this IProgramacaoOperations operations, Programacao obj, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.MudarLocalProgramacaoWithHttpMessagesAsync(obj, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='campo'>
            /// </param>
            /// <param name='term'>
            /// </param>
            public static IList<Programacao> AutoComplete(this IProgramacaoOperations operations, string campo, string term)
            {
                return Task.Factory.StartNew(s => ((IProgramacaoOperations)s).AutoCompleteAsync(campo, term), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='campo'>
            /// </param>
            /// <param name='term'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Programacao>> AutoCompleteAsync(this IProgramacaoOperations operations, string campo, string term, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.AutoCompleteWithHttpMessagesAsync(campo, term, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
