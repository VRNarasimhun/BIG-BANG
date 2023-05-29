using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using System.Diagnostics;

namespace HotelAPI.Services
{
    public class RoomRepo : ICRUD<Rooms, IdDTO>
    {
        private readonly HotelContext _context;

        public RoomRepo(HotelContext context)
        {
            _context = context;
        }
        public Rooms Add(Rooms item)
        {
            try
            {
                _context.Rooms.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public Rooms Delete(IdDTO item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Rooms> GetAll()
        {
            var room = _context.Rooms.ToList();
            if (room.Count>0)
                return room;
            return null;
        }

        public Rooms GetValue(IdDTO item)
        {
            throw new NotImplementedException();
        }

        public Rooms Update(Rooms item)
        {
            throw new NotImplementedException();
        }
    }
}
