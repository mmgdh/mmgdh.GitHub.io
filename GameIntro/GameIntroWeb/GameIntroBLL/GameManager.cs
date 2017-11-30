using GameIntroDAL;
using GameIntroModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroBLL
{
    public enum InstallResult
    {
        Success,NotEnoughDisk,UnKnownError
    }
    public static class GameManager
    {
        public static InstallResult Install(int UserDisk,int GameDisk)
        {
            try
            {
                if (UserDisk >= GameDisk)
                    return InstallResult.Success;
                else
                    return InstallResult.NotEnoughDisk;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return
                     InstallResult.UnKnownError;
            }
        }

        //添加
        public static void AddGame(Game game)
        {
            GameService.AddGame(game);
        }
        //删除游戏信息
        public static void DeleteGame(int id)
        {
             GameService.DeleteGame(id);
        }
        //
        public static void LittleModifyGame(int id,string Title)
        {
            Game game = new Game();
            game.Id = id;
            game.Title = Title;
            GameService.LittleModifyGame(game);
        }
        public static void ModifyUserDiskMessage(int Disk, int id)
        {
            GameService.ModifyUserDiskMessage(Disk, id);
        }
        public static void ModifyInstallMessage(int id)
        {
            GameService.ModifyInstallMessage(id);
        }

        //更新游戏信息
        public static void ModifyGame(int id, string Title, DateTime StartPlay, string ContentDescription, string Station, string ISBN, int isInstall, int PreferNow, string Chinese, int ISInternet, int PlayedTime, string MyEvalutation,int CategoryId)
        {
            Game game = GameService.GetGameById(id);
            game.Title = Title;
            game.PlayedTime = PlayedTime;
            game.StartPlay = StartPlay;
            game.ContentDescription = ContentDescription;
            game.Station = Station;
            game.Categories.Id = CategoryId;
            game.IsInstall = isInstall;
            game.MyEvalutation = MyEvalutation;
            game.PreferNow = PreferNow;
            game.Chinese = Chinese;
            game.IsInternet = ISInternet;
            game.ISBN = ISBN;
            game.PlayedTime = PlayedTime;
            GameService.ModifyGame(game);
        }
        //依据是否安装获得图片
        public static IList<Game> GetImgByInstall()
        {
            return GameService.GetGameImgByInstall();
        }
        //获取最近偏爱游戏
        public static Game GetGameByPreferNow(int preferNow)
        {
            return GameService.GetGameByPrefer(preferNow);
        }
        //获取细节
        public static Game GetGameById(int id)
        {
            return GameService.GetGameById(id);
        }

        public static IList<Game> GetGamePage(int categoryId, string order, int currentPage, int pageSize,int isInstall)
        {
            int startRd = currentPage * pageSize + 1;
            int endRd = (currentPage + 1) * pageSize;
            return GameService.GetGamePage(categoryId, order, startRd, endRd,isInstall);
        }
        public static IList<Game> GetGamePage(int categoryId, string order, int currentPage, int pageSize)
        {
            int startRd = currentPage * pageSize + 1;
            int endRd = (currentPage + 1) * pageSize;
            return GameService.GetGamePage(categoryId, order, startRd, endRd);
        }

        public static int getGamesCount(int categoryId)
        {
            return GameService.getGamesCount(categoryId);
        }

    }
}
