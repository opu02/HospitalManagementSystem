using BLL.Utilities;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        RoomViewModel GetRoomById(int RoomId);
        void UpdateRoom(RoomViewModel Room);
        void InsertRoom (RoomViewModel Room);
        void DeleteRoom (int id);

    }
}
