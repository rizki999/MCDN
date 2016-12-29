using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlClientDotNET {
    public static class ResourcesPath {
#if DEBUG
        public static string htmlHowTo {
            get {
                return System.IO.Directory.GetCurrentDirectory() + @"\..\..\Resources\HowToRenameDB\how-to.htm";
            }
        }

        public static string img_up_s {
            get { return @"..\..\Resources\upS.png"; }
        }
        public static string img_col_e {
            get { return @"..\..\Resources\colLEditS.png"; }
        }

        public static string img_col_a {
            get { return @"..\..\Resources\colLAddS.png"; }
        }

        public static string img_col_d {
            get { return @"..\..\Resources\colLDelS.png"; }
        }

        public static string img_db_ex1 {
            get { return @"..\..\Resources\ex_1.png"; }
        }

        public static string img_db_ex2 {
            get { return @"..\..\Resources\ex_2.png"; }
        }

        public static string img_db_ex3 {
            get { return @"..\..\Resources\ex_3.png"; }
        }
        public static string img_db_ex4 {
            get { return @"..\..\Resources\ex_4.png"; }
        }

        public static string db_conn {
            get { return @"..\..\Resources\ReadFile\db_conn.db"; }
        }
        public static string ini_file {
            get { return @"..\..\Resources\ReadFile\set_value.ini"; }
        }
        public static string img_close_S {
            get {
                return @"..\..\Resources\closeS.png";
            }
        }
        public static string img_down_S {
            get {
                return @"..\..\Resources\downS.png";
            }
        }
        public static string img_row_add_S {
            get {
                return @"..\..\Resources\row_addS.png";
            }
        }
        public static string img_rowd_del_S {
            get {
                return @"..\..\Resources\row_delS.png";
            }
        }
        public static string img_execute_S {
            get {
                return @"..\..\Resources\excuteS.png";
            }
        }
        public static string img_findreplace_S {
            get {
                return @"..\..\Resources\find_replaceS.png";
            }
        }
        public static string img_find_S {
            get {
                return @"..\..\Resources\findS.png";
            }
        }
        public static string img_save_S {
            get {
                return @"..\..\Resources\saveS.png";
            }
        }
        public static string img_saveAs_S {
            get {
                return @"..\..\Resources\saveAsS.png";
            }
        }
        public static string img_open_S {
            get {
                return @"..\..\Resources\openS.png";
            }
        }
        public static string img_warp_S {
            get {
                return @"..\..\Resources\warpS.png";
            }
        }
        public static string img_num_S {
            get {
                return @"..\..\Resources\numS.png";
            }
        }
        public static string img_database_S {
            get {
                return @"..\..\Resources\database_S.png";
            }
        }
        public static string img_database_L {
            get {
                return @"..\..\Resources\database_L.png";
            }
        }
        public static string img_table_L {
            get {
                return @"..\..\Resources\tableL.png";
            }
        }
        public static string img_table_S {
            get {
                return @"..\..\Resources\tableS.png";
            }
        }
        public static string img_database_backup_L {
            get {
                return @"..\..\Resources\database_backupL.png";
            }
        }
        public static string img_database_backup_S {
            get {
                return @"..\..\Resources\database_backupS.png";
            }
        }

        public static string img_col_L {
            get {
                return @"..\..\Resources\colL.png";
            }
        }
        public static string img_col_S {
            get {
                return @"..\..\Resources\ColS.png";
            }
        }
        public static string img_mysql_L {
            get {
                return @"..\..\Resources\MySQL_Client_DOT_NET_-_LOGO.png";
            }
        }
        public static string img_conn_L {
            get {
                return @"..\..\Resources\connL.png";
            }
        }
        public static string img_logo {
            get {
                return @"..\..\Resources\MySQL_Client_DOT_NET.png";
            }
        }

        public static string img_database_alter_S {
            get {
                return @"..\..\Resources\database_alterS.png";
            }
        }

        public static string img_database_create_S {
            get {
                return @"..\..\Resources\database_createS.png";
            }
        }

        public static string img_database_drop_S {
            get {
                return @"..\..\Resources\database_dropS.png";
            }
        }

        public static string img_table_alter_S {
            get {
                return @"..\..\Resources\table_editS.png";
            }
        }

        public static string img_table_create_S {
            get {
                return @"..\..\Resources\table_addS.png";
            }
        }

        public static string img_table_drop_S {
            get {
                return @"..\..\Resources\table_removeS.png";
            }
        }
        public static string img_refresh_S {
            get {
                return @"..\..\Resources\refreshS.png";
            }
        }
        public static string img_database_use_S {
            get {
                return @"..\..\Resources\database_useS.png";
            }
        }

#else
        public static string htmlHowTo {
            get {
                return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\MCDN\HowToRenameDB\how-to.htm";
            }
        }

        public static string db_conn {
            get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\MCDN\db_conn.db"; }
        }

        public static string ini_file {
            get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\MCDN\set_value.ini"; }
        }

        public static string img_up_s {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\upS.png"; }
        }

        public static string img_col_e {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\colLEditS.png"; }
        }

        public static string img_col_a {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\colLAddS.png"; }
        }
        public static string img_col_d {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\colLDelS.png"; }
        }
        public static string img_db_ex1 {
            get { 
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\ex_1.png"; 
            }
        }
        public static string img_db_ex2 {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +  @"\Resources\ex_2.png"; }
        }
        public static string img_db_ex3 {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\ex_3.png"; }
        }
        public static string img_db_ex4 {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\ex_4.png"; }
        }


        public static string img_close_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\closeS.png";
            }
        }
        public static string img_down_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\downS.png";
            }
        }
        public static string img_row_add_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\row_addS.png";
            }
        }
        public static string img_rowd_del_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\row_delS.png";
            }
        }
        public static string img_execute_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\excuteS.png";
            }
        }
        public static string img_findreplace_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\find_replaceS.png";
            }
        }
        public static string img_find_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\findS.png";
            }
        }
        public static string img_save_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\saveS.png";
            }
        }
        public static string img_saveAs_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\saveAsS.png";
            }
        }
        public static string img_open_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\openS.png";
            }
        }
        public static string img_warp_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\warpS.png";
            }
        }
        public static string img_num_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\numS.png";
            }
        }
        public static string img_database_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_S.png";
            }
        }
        public static string img_database_L {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_L.png";
            }
        }
        public static string img_table_L {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\tableL.png";
            }
        }
        public static string img_table_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\tableS.png";
            }
        }
        public static string img_database_backup_L {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_backupL.png";
            }
        }
        public static string img_database_backup_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_backupS.png";
            }
        }

        public static string img_col_L {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\colL.png";
            }
        }
        public static string img_col_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\ColS.png";
            }
        }
        public static string img_mysql_L {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\MySQL_Client_DOT_NET_-_LOGO.png";
            }
        }
        public static string img_conn_L {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\connL.png";
            }
        }
        public static string img_logo {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\MySQL_Client_DOT_NET.png";
            }
        }

        public static string img_database_alter_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_alterS.png";
            }
        }

        public static string img_database_create_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_createS.png";
            }
        }

        public static string img_database_drop_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_dropS.png";
            }
        }

        public static string img_table_alter_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\table_editS.png";
            }
        }

        public static string img_table_create_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\table_addS.png";
            }
        }

        public static string img_table_drop_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\table_removeS.png";
            }
        }
        public static string img_refresh_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\refreshS.png";
            }
        }
        public static string img_database_use_S {
            get {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\database_useS.png";
            }
        }
#endif
    }
}
