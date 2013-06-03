// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.SqlServerCompact.SqlGen
{
    using System.Data.Entity.SqlServerCompact.Utilities;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    internal class SqlStringBuilder
    {
        private readonly StringBuilder _sql;

        public SqlStringBuilder()
        {
            _sql = new StringBuilder();
        }

        public SqlStringBuilder(int capacity)
        {
            _sql = new StringBuilder(capacity);
        }

        public bool UpperCaseKeywords { get; set; }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public SqlStringBuilder AppendKeyWord(string keyword)
        {
            DebugCheck.NotNull(keyword);

            _sql.Append(
                UpperCaseKeywords
                    ? keyword.ToUpperInvariant()
                    : keyword.ToLowerInvariant());

            return this;
        }

        public SqlStringBuilder AppendLine()
        {
            _sql.AppendLine();

            return this;
        }

        public SqlStringBuilder AppendLine(string s)
        {
            _sql.AppendLine(s);

            return this;
        }

        public SqlStringBuilder Append(string s)
        {
            _sql.Append(s);

            return this;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
            MessageId = "System.Text.StringBuilder.AppendFormat(System.String,System.Object[])")]
        public SqlStringBuilder AppendFormat(string format, params object[] args)
        {
            _sql.AppendFormat(format, args);

            return this;
        }

        public int Length
        {
            get { return _sql.Length; }
            set { _sql.Length = value; }
        }

        public override string ToString()
        {
            return _sql.ToString();
        }
    }
}