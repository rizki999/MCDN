using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MySqlClientDotNET.MySqlUtil {
    public class CheckingSQLSyntax {
        public CheckingSQLSyntax() {
            lengtLimit = 0;
            sql = string.Empty;
        }

        public bool isContainFrom(string tmpSql) {
            var matches = Regex.Matches(tmpSql, @"(?<unquote>[^""'`\s]+)|(?:[""][^""]+?[""])|(?:['][^']+?['])|(?:[`][^`]+?[`])", RegexOptions.Multiline);
            foreach (Match match in matches) {
                if (match.Groups["unquote"].Success) {
                    string tmp = match.Groups["unquote"].Value.Trim().ToUpper();
                    if (tmp.Equals("FROM")) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isContainLimit(string tmpSql) {
            var matches = Regex.Matches(tmpSql, @"(?<unquote>[^""'`\s]+)|(?:[""][^""]+?[""])|(?:['][^']+?['])|(?:[`][^`]+?[`])", RegexOptions.Multiline);
            bool isContain = false;
            int index = 0;
            foreach (Match match in matches) {
                if (match.Groups["unquote"].Success) {
                    string tmp = match.Groups["unquote"].Value.Trim().ToUpper();
                    if (tmp.Equals("LIMIT")) {
                        index = match.Groups["unquote"].Index;
                        isContain = true;
                    }
                }
            }
            if (isContain) {
                if (!isOutsideBrackets(tmpSql, index))
                    return false;
                sql = tmpSql.Remove(index);
                string[] num = tmpSql.Remove(0, index + 5).Split(',');
                if (num.Length < 2)
                    return false;
                if (!int.TryParse(num[1], out lengtLimit) || !int.TryParse(num[0], out startLimit))
                    return false;
                return true;
            }
            return false;
        }

        private bool isOutsideBrackets(string val, int idx) {
            if (val.Length < 4)
                return true;
            if (idx < 4)
                return true;
            int index_b = 0;
            bool isBrackets = false;
            for (int i = 0; i < idx; ++i) {
                if (val[i] == ')') {
                    isBrackets = true;
                    index_b = i;
                }
            }
            if (isBrackets) {
                if (index_b < idx)
                    return true;
            } else
                return true;
            return false;
        }

        private int lengtLimit;
        private int startLimit;
        private string sql;
        public int LengtLimit { get { return lengtLimit; } }
        public int StartLimit { get { return startLimit; } }
        public string Sql { get { return sql; } }
    }
}
