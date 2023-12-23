﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace GamesAPI.Shared
{
    public static class SqlExtensions
    {
        public static SqlConnection CreateOpenConnection(this string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        //Command Extensions
        public static SqlCommand CreateCommand(
            this SqlConnection connection,
            CommandType commandType,
            string commandText,
            int commandTimeout = 30)
        {
            return new SqlCommand
            {
                Connection = connection,
                CommandType = commandType,
                CommandText = commandText,
                CommandTimeout = commandTimeout
            };
        }

        public static void CreateBooleanInputParameter(this SqlCommand command, string parameterName, bool? parameterValue)
        {
            object value = DBNull.Value;

            if (parameterValue.HasValue)
            {
                value = parameterValue.Value;
            }

            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Byte;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = value;

            command.Parameters.Add(parameter);
        }

        public static void CreateDateTimeInputParameter(this SqlCommand command, string parameterName, DateTime? parameterValue)
        {
            object value = DBNull.Value;

            if (parameterValue.HasValue && parameterValue.Value != DateTime.MinValue)
            {
                value = parameterValue.Value;
            }

            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.DateTime;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = value;

            command.Parameters.Add(parameter);
        }

        public static void CreateStringInputParameter(this SqlCommand command, string parameterName, string parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.String;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = string.IsNullOrWhiteSpace(parameterValue) ? (object)DBNull.Value : parameterValue;

            command.Parameters.Add(parameter);
        }

        public static void CreateGuidInputParameter(this SqlCommand command, string parameterName, Guid parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Guid;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = parameterValue;

            command.Parameters.Add(parameter);
        }

        public static void CreateIntInputParameter(this SqlCommand command, string parameterName, int parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Int32;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = parameterValue;

            command.Parameters.Add(parameter);
        }

        public static void CreateNullableIntInputParameter(this SqlCommand command, string parameterName, int? parameterValue)
        {
            object value = DBNull.Value;

            if (parameterValue.HasValue)
            {
                value = parameterValue.Value;
            }

            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Int32;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = value;

            command.Parameters.Add(parameter);
        }

        public static void CreateDoubleInputParameter(this SqlCommand command, string parameterName, double parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Double;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = parameterValue;

            command.Parameters.Add(parameter);
        }

        public static void CreateXmlInputParameter(this SqlCommand command, string parameterName, string parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Xml;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = string.IsNullOrWhiteSpace(parameterValue) ? (object)DBNull.Value : parameterValue;

            command.Parameters.Add(parameter);
        }

        public static void CreateBinaryInputParameter(this SqlCommand command, string parameterName, byte[] parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Binary;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = parameterValue;

            command.Parameters.Add(parameter);
        }

        public static void CreateBinaryOrNullInputParameter(this SqlCommand command, string parameterName, byte[] parameterValue)
        {
            object value = DBNull.Value;

            if (parameterValue != null)
            {
                value = parameterValue;
            }

            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.DbType = DbType.Binary;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = value;

            command.Parameters.Add(parameter);
        }
    }
}