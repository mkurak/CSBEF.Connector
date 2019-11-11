using CSBEF.Connector.Enums;
using CSBEF.Connector.Interfaces;
using CSBEF.Connector.Models;
using Microsoft.Extensions.Logging;
using System;

namespace CSBEF.Core.Models
{
    public class ReturnModel<TResult>
    {
        #region Dependencies

        private readonly ILogger<ILog> _logger;

        #endregion Dependencies

        #region Public Properties

        public ErrorResult Error { get; set; }
        public TResult Result { get; set; }

        #endregion Public Properties

        #region Construction

        public ReturnModel(ILogger<ILog> logger)
        {
            _logger = logger;
            Error = new ErrorResult();
        }

        #endregion Construction

        #region Public Actions

        public ReturnModel<TResult> SendError<T>(T error)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return SendError(GlobalErrors.TechnicalError);

            Error.Code = error.ToString();
            Error.Message = Enum.GetName(typeof(T), error);
            Error.Status = true;

            _logger.LogError("(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError<T>(T error, Exception ex)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return SendError(GlobalErrors.TechnicalError);

            Error.Code = error.ToString();
            Error.Message = Enum.GetName(typeof(T), error);
            Error.Status = true;

            _logger.LogError(ex, "(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError<T>(T error, Exception ex, TResult result)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return SendError(GlobalErrors.TechnicalError);

            Error.Code = error.ToString();
            Error.Message = Enum.GetName(typeof(T), error);
            Error.Status = true;
            Result = result;

            _logger.LogError(ex, "(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError(string message)
        {
            Error.Code = "";
            Error.Message = message;
            Error.Status = true;

            _logger.LogError("(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError(string message, Exception ex)
        {
            Error.Code = "";
            Error.Message = message;
            Error.Status = true;

            _logger.LogError(ex, "(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError(string message, Exception ex, TResult result)
        {
            Error.Code = "";
            Error.Message = message;
            Error.Status = true;
            Result = result;

            _logger.LogError(ex, "(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError(string message, string code)
        {
            Error.Code = code;
            Error.Message = message;
            Error.Status = true;

            _logger.LogError("(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError(string message, string code, Exception ex)
        {
            Error.Code = code;
            Error.Message = message;
            Error.Status = true;

            _logger.LogError(ex, "(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendError(string message, string code, Exception ex, TResult result)
        {
            Error.Code = code;
            Error.Message = message;
            Error.Status = true;
            Result = result;

            _logger.LogError(ex, "(" + Error.Code + ")" + Error.Message);

            return this;
        }

        public ReturnModel<TResult> SendResult(TResult result)
        {
            Result = result;

            return this;
        }

        #endregion Public Actions
    }
}