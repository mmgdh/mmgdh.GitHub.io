using MyBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroModel
{
    public class Game
    {
        private int id;
        private string title;
        private string station;
        private DateTime startPlay;
        private string contentDescription;
        private User userid;
        private Category categories;
        private int isInstall;
        private string iSBN;
        private int preferNow;
        private string chinese;
        private int playedTime;
        private string myEvalutation;
        private int isInternet;
        private int disk;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Station
        {
            get
            {
                return station;
            }

            set
            {
                station = value;
            }
        }

        public DateTime StartPlay
        {
            get
            {
                return startPlay;
            }

            set
            {
                startPlay = value;
            }
        }

        public string ContentDescription
        {
            get
            {
                return contentDescription;
            }

            set
            {
                contentDescription = value;
            }
        }

        public User Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public Category Categories
        {
            get
            {
                return categories;
            }

            set
            {
                categories = value;
            }
        }

        public int IsInstall
        {
            get
            {
                return isInstall;
            }

            set
            {
                isInstall = value;
            }
        }


        public int PreferNow
        {
            get
            {
                return preferNow;
            }

            set
            {
                preferNow = value;
            }
        }

        public string ISBN
        {
            get
            {
                return iSBN;
            }

            set
            {
                iSBN = value;
            }
        }

        public string Chinese
        {
            get
            {
                return chinese;
            }

            set
            {
                chinese = value;
            }
        }

        public int PlayedTime
        {
            get
            {
                return playedTime;
            }

            set
            {
                playedTime = value;
            }
        }

        public string MyEvalutation
        {
            get
            {
                return myEvalutation;
            }

            set
            {
                myEvalutation = value;
            }
        }

        public int IsInternet
        {
            get
            {
                return isInternet;
            }

            set
            {
                isInternet = value;
            }
        }

        public int Disk
        {
            get
            {
                return disk;
            }

            set
            {
                disk = value;
            }
        }
    }
}
