using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain
{
    public class SeatAvailabilityDto
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public int AvailableSeats { get; set; }

        public int OccupiedSeats { get; set; }
        public SeatAvailabilityDto()
        {
            AvailableSeats = 0;
        }
        public SeatAvailabilityDto(int roomId, string roomName, int availableSeats, int occupiedSeats)
        {
            RoomId = roomId;
            RoomName = roomName;
            AvailableSeats = availableSeats;
            OccupiedSeats = occupiedSeats;
        }
        public SeatAvailabilityDto(string roomName, int availableSeats, int occupiedSeats)
        {
            RoomName = roomName;
            AvailableSeats = availableSeats;
            OccupiedSeats = occupiedSeats;
        }
    }
}
