using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;

namespace HotelAPI.Services
{
    public class HotelService
    {
        private readonly ICRUD<Hotel, IdDTO> _hotelRepo;
        private ICRUD<Rooms, IdDTO> _roomRepo;

        public HotelService(ICRUD<Hotel, IdDTO> hotelRepo, ICRUD<Rooms, IdDTO> roomRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
        }

        public Hotel AddHotel(Hotel hotel)
        {
            var myHotel = _hotelRepo.Add(hotel);
            if (myHotel != null)
                return myHotel;
            return null;
        }

        public Rooms AddRoom(Rooms room)
        {
            var hotels = _hotelRepo.GetAll();
            var hotel = hotels.FirstOrDefault(h => h.H_id == room.H_id);
            var myRoom = _roomRepo.Add(room);
            if (myRoom != null && hotel != null)
                return myRoom;
            return null;
        }

        public List<Hotel> GetAllHotels()
        {
            var hotels = _hotelRepo.GetAll().ToList();
            if (hotels.Count > 0)
                return hotels;
            return null;
        }

        public List<Rooms> GetAllRooms()
        {
            var rooms = _roomRepo.GetAll().ToList();
            if (rooms.Count > 0)
                return rooms;
            return null;
        }
    }
}
