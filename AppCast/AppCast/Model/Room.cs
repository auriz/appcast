using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCast.Model
{
    class Room
    {
        private int roomID;
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        private String roomTitle;

        public String RoomTitle
        {
            get { return roomTitle; }
            set { roomTitle = value; }
        }

        private String roomUser;

        public String RoomUser
        {
            get { return roomUser; }
            set { roomUser = value; }
        }

        private int keyID;

        public int KeyID
        {
            get { return keyID; }
            set { keyID = value; }
        }

        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

    }
}
