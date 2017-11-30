using GameIntroModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroDAL
{
    public static  class GameService
    {
        //添加
        public static Game AddGame(Game game)
        {
            string sql =
                "INSERT Game (Title,UserId,StartPlay,ContentDescription,Station,CategoryId,ISBN,isInstall,PreferNow,Chinese,ISInternet,PlayedTime,MyEvaluation)" +
                "VALUES (@Title, @UserId, @StartPlay, @ContentDescription, @Station, @CategoryId, @ISBN, @isInstall, @PreferNow, @Chinese, @ISInternet, @PlayedTime, @MyEvaluation)";

            sql += " ; SELECT @@IDENTITY";

            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Title", game.Title), //FK
					new SqlParameter("@UserId", 2), //FK
					new SqlParameter("@StartPlay", game.StartPlay),
                    new SqlParameter("@ContentDescription",game.ContentDescription),
                    new SqlParameter("@Station", game.Station),
                    new SqlParameter("@CategoryId", game.Categories.Id),
                    new SqlParameter("@ISBN", game.ISBN),
                    new SqlParameter("@isInstall", game.IsInstall),
                    new SqlParameter("@PreferNow", game.PreferNow),
                    new SqlParameter("@Chinese", game.Chinese),
                    new SqlParameter("@ISInternet", game.IsInternet),
                    new SqlParameter("@PlayedTime", game.PlayedTime),
                    new SqlParameter("@MyEvaluation", game.MyEvalutation)
                };

                int newId = DBHelper.GetScalar(sql, para);
                return GetGameById(newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //删除
        public static void DeleteGame(int id)
        {
            string sql = "Delete from Game where id=@Id";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id),
            };
            DBHelper.ExecuteCommand(sql, para);
        }
        //尝试更新
        public static void LittleModifyGame(Game game)
        {
            string sql =
                "UPDATE Game " +
                "SET " +
                    "Title = @Title " +
                "WHERE Id = @Id";
            SqlParameter[] para = new SqlParameter[]
           {
                new SqlParameter("@Id", game.Id),
                new SqlParameter("@Title", game.Title), //FK
           };
            DBHelper.ExecuteCommand(sql, para);
        }
        public static void ModifyInstallMessage(int id)
        {
            string sql = "Update Game set IsInstall=1 where id=@Id";
            SqlParameter[] para = new SqlParameter[]
          {
                new SqlParameter("@Id", id),
          };
            DBHelper.ExecuteCommand(sql, para);
        }
        public static void ModifyUserDiskMessage(int Disk,int id)
        {
            string sql = "Update Users set EmptyDisk=@Disk where id=@id";
            SqlParameter[] para = new SqlParameter[]
          {
                new SqlParameter("@Disk", Disk),
                new SqlParameter("@id", id),
          };
            DBHelper.ExecuteCommand(sql, para);
        }
        //更新游戏信息
        public static void ModifyGame(Game game)
        {
            string sql =
                "UPDATE Game " +
                "SET " +
                    "Title = @Title, " + //FK
                    "StartPlay = @StartPlay, " +
                    "ContentDescription = @ContentDescription, " +
                    "Station = @Station, " +
                    "IsInstall = @IsInstall, " +
                    "CategoryId = @CategoryId, " +
                    "ISBN = @ISBN, " +
                    "PreferNow = @PreferNow, " +
                    "Chinese = @Chinese, " +
                    "IsInternet = @IsInternet, " +
                    "PlayedTime = @PlayedTime, " +
                    "MyEvaluation = @MyEvaluation " +
                "WHERE Id = @Id";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", game.Id),
                new SqlParameter("@Title", game.Title), //FK
				new SqlParameter("@StartPlay", game.StartPlay), //FK
				new SqlParameter("@ContentDescription", game.ContentDescription),
                new SqlParameter("@Station",game.Station),
                new SqlParameter("@CategoryId",game.Categories.Id),
                new SqlParameter("@ISBN", game.ISBN),
                new SqlParameter("@isInstall", game.IsInstall),
                new SqlParameter("@PreferNow", game.PreferNow),
                new SqlParameter("@Chinese",game.Chinese),
                new SqlParameter("@IsInternet",game.IsInternet),
                new SqlParameter("@PlayedTime",game.PlayedTime),
                new SqlParameter("@MyEvaluation",game.MyEvalutation)
            };
            DBHelper.ExecuteCommand(sql, para);
        }
        //根据是否安装查找图片
        public static IList<Game> GetGameImgByInstall()
        {
            string sql = "Select ID,Title,ISBN From Game where isInstall=1";
            List<Game> list = new List<Game>();
            try
            {
                DataTable table = DBHelper.GetDataSet(sql);
                foreach (DataRow row in table.Rows)
                {
                    Game game = new Game();
                    game.Id = (int)row["ID"];
                    game.ISBN = (string)row["ISBN"];
                    game.Title = (string)row["Title"];
                    list.Add(game);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //查找最近偏爱
        public static Game GetGameByPrefer(int PreferNow)
        {
            string sql = "Select * from Game where preferNow=@preferNow";
            int categoryId;
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@preferNow", PreferNow));
                if (reader.Read())
                {
                    Game game = new Game();
                    game.Id = (int)reader["Id"];
                    game.Title = (string)reader["Title"];
                    game.ContentDescription = (string)reader["ContentDescription"];
                    game.ISBN = (string)reader["ISBN"];
                    game.Chinese = (string)reader["Chinese"];
                    categoryId = (int)reader["CategoryId"];
                    reader.Close();
                    game.Categories = CategoryService.GetCategoryById(categoryId);
          
                    return game;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
        //查找游戏详细信息
        public static Game GetGameById(int id)
        {
            string sql = "SELECT * FROM Game WHERE Id = @Id";

            int categoryId;

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Game game = new Game();
                    game.Id = (int)reader["Id"];
                    game.Title = (string)reader["Title"];
                    game.StartPlay = (DateTime)reader["startPlay"];
                    game.ContentDescription = (string)reader["ContentDescription"];
                    game.ISBN = (string)reader["ISBN"];
                    game.Chinese = (string)reader["chinese"];
                    game.PlayedTime = (int)reader["PlayedTime"];
                    game.MyEvalutation = (string)reader["MyEvaluation"];
                    game.Station = (string)reader["Station"];
                    game.Disk = (int)reader["Disk"];
                    game.IsInstall = (int)reader["isInstall"];
                    game.PreferNow = (int)reader["PreferNow"];
                    game.IsInternet = (int)reader["ISInternet"];
                    categoryId = (int)reader["CategoryId"]; //FK
                    reader.Close();
                    game.Categories = CategoryService.GetCategoryById(categoryId);
                    return game;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //
        public static IList<Game> GetGamePage(int categoryId, string order, int startRd, int endRd,int isInstall)
        {
            string sql = "";
            if (categoryId > 0)
            {
                 sql = "select Id, Title, StartPlay, Station, CategoryId,ISBN,isInstall,PreferNow,Chinese,ISInternet,Disk,PlayedTime, SubString(ContentDescription,0,200) as ShortContent from ";
                sql += "(SELECT ROW_NUMBER() OVER (ORDER BY " + order + " ,Id) AS PriceRank,* FROM Game WHERE CategoryId = " + categoryId + "and isInstall=" + isInstall+" ) AS Rank";
                sql += " WHERE CategoryId = " + categoryId+"and isInstall ="+isInstall + " and PriceRank BETWEEN " + startRd + " and " + endRd + " ORDER BY " + order + " ,Id";
            }
            else
            {
                 sql = "select Id, Title, StartPlay, Station, CategoryId,ISBN,isInstall,PreferNow,Chinese,ISInternet,Disk,PlayedTime, SubString(ContentDescription,0,200) as ShortContent from ";
                sql += "(SELECT ROW_NUMBER() OVER (ORDER BY " + order + " ,Id) AS PriceRank,* FROM Game WHERE isInstall=" + isInstall + " ) AS Rank";
                sql += " WHERE isInstall="+isInstall+"and PriceRank BETWEEN " + startRd + " and " + endRd + " ORDER BY " + order + " ,Id";
            }
            
            return GetSmallGameBySql(sql);
        }
        public static IList<Game> GetGamePage(int categoryId, string order, int startRd, int endRd)
        {
            string sql = "";
            if (categoryId > 0)
            {
                sql = "select Id, Title, StartPlay, Station, CategoryId,ISBN,isInstall,PreferNow,Chinese,ISInternet,Disk,PlayedTime, SubString(ContentDescription,0,200) as ShortContent from ";
                sql += "(SELECT ROW_NUMBER() OVER (ORDER BY " + order + " ,Id) AS PriceRank,* FROM Game WHERE CategoryId = " + categoryId +" ) AS Rank";
                sql += " WHERE CategoryId = " + categoryId  + " and PriceRank BETWEEN " + startRd + " and " + endRd + " ORDER BY " + order + " ,Id";
            }
            else
            {
                sql = "select Id, Title, StartPlay, Station, CategoryId,ISBN,isInstall,PreferNow,Chinese,ISInternet,Disk,PlayedTime, SubString(ContentDescription,0,200) as ShortContent from ";
                sql += "(SELECT ROW_NUMBER() OVER (ORDER BY " + order + " ,Id) AS PriceRank,* FROM Game  ) AS Rank";
                sql += " WHERE PriceRank BETWEEN " + startRd + " and " + endRd + " ORDER BY " + order + " ,Id";
            }

            return GetSmallGameBySql(sql);
        }
        public static int getGamesCount(int categoryId)
        {
            string sql = "";
            if (categoryId > 0)
            {
                sql = "SELECT count(*) FROM Game where CategoryId = " + categoryId;
            }
            else
            {
                sql = "SELECT count(*) FROM Game";
            }
            
            return DBHelper.GetScalar(sql);
        }
        private static IList<Game> GetSmallGameBySql(string safeSql)
        {
            int categoryId;
            List<Game> list = new List<Game>();
            DataTable table = DBHelper.GetDataSet(safeSql);
            foreach (DataRow row in table.Rows)
            {
                Game game = new Game();
                game.Id = (int)row["Id"];
                game.Title = (string)row["Title"];
                game.ISBN = (string)row["ISBN"];
                game.Station = (string)row["Station"];
                game.StartPlay = (DateTime)row["StartPlay"];
                categoryId = (int)row["CategoryId"];
                game.Chinese = (string)row["Chinese"];
                game.PlayedTime = (int)row["PlayedTime"];
                game.ContentDescription = (string)row["ShortContent"];
                game.Disk = (int)row["Disk"];
                game.Categories = CategoryService.GetCategoryById(categoryId);
                list.Add(game);
            }
            return list;
        }
        private static IList<Game> GetgamesBySql(string safeSql)
        {
            List<Game> list = new List<Game>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    Game game = new Game();

                    game.Id = (int)row["Id"];
                    game.Title = (string)row["Title"];
                
                    list.Add(game);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

        private static IList<Game> GetgamesBySql(string sql, params SqlParameter[] values)
        {
            List<Game> list = new List<Game>();

            try
            {
                DataTable table = DBHelper.GetDataSet(sql, values);

                foreach (DataRow row in table.Rows)
                {
                    Game game = new Game();

                    game.Id = (int)row["Id"];
                    game.Title = (string)row["Title"];

                    list.Add(game);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

    }
}
