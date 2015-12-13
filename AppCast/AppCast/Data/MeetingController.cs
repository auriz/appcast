using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCast.Model;

namespace AppCast.Data
{
    class MeetingController
    {
        public List<string> getUsers(string userid)
        {
            List<string> uList = new List<string>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    var q = from u in db.AppUsers
                            where u.userID != userid
                            select u.name;
                    uList = q.ToList();
                }
                catch (Exception e)
                {

                }
            }

            return uList;
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
            key.symKey = "test";
            key.symKey2 = "test2";

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

        public List<string> getRoom(string userid)
        {
            List<string> rList = new List<string>();

            using (AppCastEntities db = new AppCastEntities())
            {
                try
                {
                    var q = from r in db.Rooms
                            select r.roomTitle;
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

                return db.KeyManagers.OrderBy(z => z.keyID).FirstOrDefault().keyID;
            }
        }
    }
}
