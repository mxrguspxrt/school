using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Client.Models
{
    class GameUser
    {
        public int Id;
        public string Name;
        public int CurrentPlayId;
        public bool Active;

        public bool SetValuesFrom(TripsService.GameUser gameUser)
        {
            this.Id = gameUser.Id;
            this.Name = gameUser.Name;
            this.CurrentPlayId = gameUser.CurrentPlayId;
            this.Active = gameUser.Active;
            return true;
        }

        public GameUser()
        {

        }

        public GameUser(TripsService.GameUser gameUser)
        {
            this.SetValuesFrom(gameUser);
        }

        public bool Save()
        {
            return Create();
        }

        private bool Create()
        {
            TripsService.TripsServiceClient link = new TripsService.TripsServiceClient();
            TripsService.GameUser resource = link.GameUser_Register(this.Name);
            this.SetValuesFrom(resource);
            System.Diagnostics.Debug.WriteLine("Created GameUser " + this.Name);
            return true;
        }

    }
}
