using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCast.Model;
using System.Data.Entity;

namespace AppCast.Data
{
    class MeetingController
    {
        public List<AppUser> getUsers(string userid)
        {
            List<string> uList = new List<string>();
            List<AppUser> userList = new List<AppUser>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    //var q = from u in db.AppUsers
                    //        where u.userID != userid
                    //        select u.name;
                    //uList = q.ToList();
                    var q = from u in db.Contacts
                            where u.userID.Equals(userid) && u.status.Equals("Confirm")
                            select u.friendID;
                    uList = q.ToList();
                    foreach (string s in uList)
                    {
                        userList.Add(new Data.ContactController().getUser(s));
                    }
                }
                catch (Exception e)
                {

                }
            }
            return userList;
        }
        public bool createRoom(string userid, string roomTitle, string roomUser)
        {
            bool status = false;

            Room room = new Room();
            room.roomTitle = roomTitle;
            room.createUser = userid;
            room.createDate = DateTime.Now;
            room.roomUser = roomUser;

            KeyManager key = new KeyManager();
            key.symKey = new Encryption().generateKey();

            room.keyID = addKey(key);

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    db.Rooms.Add(room);
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception e)
                {
                    status = false;
                }
            }
            return status;
        }
        public List<Room> getRoom(string userid)
        {
            List<Room> rList = new List<Room>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    var q = from r in db.Rooms
                            where r.roomUser.Contains(userid) || r.createUser.Equals(userid)
                            select r;
                    rList = q.ToList();
                }
                catch(Exception e){

                }
            }

            return rList;
        }
        public int addKey(KeyManager key)
        {
            
            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    db.KeyManagers.Add(key);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return 0;
                }

                return db.KeyManagers.OrderByDescending(z => z.keyID).FirstOrDefault().keyID;
            }
        }
        public string getRoomUsers(int roomID)
        {
            string roomUsers = null;
            Room room = new Room();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    var q = from r in db.Rooms
                            where r.roomID.Equals(roomID)
                            select r;
                    room = db.Rooms.FirstOrDefault(r => r.roomID.Equals(roomID));
                    roomUsers = room.roomUser;
                }
                catch (Exception e)
                {

                }
            }

            return roomUsers;
        }
        public List<string> roomUserParser(string roomUsers)
        {
            List<string> uList = new List<string>();

            uList = roomUsers.Split(',').ToList();

            return uList;
        }
        public string roomListParser(List<string> uList)
        {
            string users = "";

            foreach(string s in uList)
            {
                users += "," + s;
            }
            users = users.Substring(1);

            return users;
        }
        public bool deleteRoom(int roomID, string roomName)
        {
            bool status = false;

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    Room room = new Room();
                    room.roomID = roomID;
                    room.roomTitle = roomName;
                    db.Rooms.Attach(room);
                    db.Rooms.Remove(room);
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception e)
                {

                }
            }

            return status;
        }
        public bool addUserToRoom(int roomID, string userid)
        {
            bool status = false;
            string users = "";
            List<string> userList = new List<string>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    Room room = db.Rooms.FirstOrDefault(r => r.roomID.Equals(roomID));
                    users = room.roomUser;
                    userList = roomUserParser(users);
                    if (userList.Contains(userid))
                        return status;
                    else
                    {
                        userList.Add(userid);
                        users += "," + userid;
                        room.roomUser = users;
                        db.Rooms.Attach(room);
                        db.Entry(room).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (Exception e){

                }
            }

            return status;
        }
        public bool delUserFromRoom(int roomID, string userid)
        {
            bool status = false;
            string users = "";
            List<string> userList = new List<string>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    Room room = db.Rooms.FirstOrDefault(r => r.roomID.Equals(roomID));
                    users = room.roomUser;
                    userList = roomUserParser(users);
                    if (userList.Contains(userid))
                    {
                        userList.Remove(userid);
                        users = roomListParser(userList);
                        room.roomUser = users;
                        db.Rooms.Attach(room);
                        db.Entry(room).State = EntityState.Modified;
                        db.SaveChanges();
                    }                      
                    else
                        return status;
                }
                catch (Exception e)
                {

                }
            }

            return status;
        }
        public bool editRoomUser(int roomID, string userid)
        {
            bool status = false;
            List<string> newUserList = new List<string>();
            newUserList = roomUserParser(userid);

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    Room room = db.Rooms.FirstOrDefault(r => r.roomID.Equals(roomID));
                    room.roomUser = userid;
                    db.Rooms.Attach(room);
                    db.Entry(room).State = EntityState.Modified;
                    db.SaveChanges();              
                }
                catch (Exception e)
                {

                }
            }

            return status;
        }
        public List<string> getRoomUserList(int roomID)
        {
            List<string> uList = new List<string>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    Room room = db.Rooms.FirstOrDefault(r => r.roomID.Equals(roomID));
                    uList = roomUserParser(room.roomUser);
                }
                catch (Exception e)
                {

                }
            }

            return uList;
        }
    }
}
