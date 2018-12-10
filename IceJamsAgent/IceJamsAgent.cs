//------------------------------------------------------------------------------
//----- ServiceAgent -------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   The service agent is responsible for initiating the service call, 
//              capturing the data that's returned and forwarding the data back to 
//              the requestor.
//
//discussion:   
//
// 

using System;
using System.Collections.Generic;
using IceJamsAgent.Resources;
using WiM.Utilities;
using WiM.Resources;
using IceJamsDB.Resources;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IceJamsDB;
using WiM.Security.Authentication.Basic;

namespace IceJamsAgent
{
    public interface IIceJamsAgent:IMessage
    {
        //Agencies
        IQueryable<Agency> GetAgencies();
        Task<Agency> GetAgency(Int32 ID);
        Task<Agency> Add(Agency item);
        Task<IEnumerable<Agency>> Add(List<Agency> items);
        Task<Agency> Update(Int32 pkId, Agency item);
        Task DeleteAgency(Int32 pkID);

        //Damages (Available via Event)
      
        //DamageTypes
        IQueryable<DamageType> GetDamageTypes();
        Task<DamageType> GetDamageType(Int32 ID);
        Task<DamageType> Add(DamageType item);
        Task<IEnumerable<DamageType>> Add(List<DamageType> items);
        Task<DamageType> Update(Int32 pkId, DamageType item);
        Task DeleteDamageType(Int32 pkID);

        //Event
        //TODO, add methods to access Event

        //File (Available via Event)

        //FileType
        IQueryable<FileType> GetFileTypes();
        Task<FileType> GetFileType(Int32 ID);
        Task<FileType> Add(FileType item);
        Task<IEnumerable<FileType>> Add(List<FileType> items);
        Task<FileType> Update(Int32 pkId, FileType item);
        Task DeleteFileType(Int32 pkID);

        //IceConditions (Available via Event)

        //IceConditionTypes
        IQueryable<IceConditionType> GetIceConditionTypes();
        Task<IceConditionType> GetIceConditionType(Int32 ID);
        Task<IceConditionType> Add(IceConditionType item);
        Task<IEnumerable<IceConditionType>> Add(List<IceConditionType> items);
        Task<IceConditionType> Update(Int32 pkId, IceConditionType item);
        Task DeleteIceConditionType(Int32 pkID);

        //IceJam (Available via Event)

        //JamTypes
        IQueryable<JamType> GetJamTypes();
        Task<JamType> GetJamType(Int32 ID);
        Task<JamType> Add(JamType item);
        Task<IEnumerable<JamType>> Add(List<JamType> items);
        Task<JamType> Update(Int32 pkId, JamType item);
        Task DeleteJamType(Int32 pkID);

        //Observer
        IQueryable<Observer> GetObservers();
        Task<Observer> GetObserver(Int32 ID);
        Task<Observer> FindObserver(int ID);
        Task<Observer> Add(Observer item);
        Task<IEnumerable<Observer>> Add(List<Observer> items);
        Task<Observer> Update(Int32 pkId, Observer item);
        Task DeleteObserver(Int32 pkID);

        //RiverConditions (Available via Event)

        //RiverConditionTypes
        IQueryable<RiverConditionType> GetRiverConditionTypes();
        Task<RiverConditionType> GetRiverConditionType(Int32 ID);
        Task<RiverConditionType> Add(RiverConditionType item);
        Task<IEnumerable<RiverConditionType>> Add(List<RiverConditionType> items);
        Task<RiverConditionType> Update(Int32 pkId, RiverConditionType item);
        Task DeleteRiverConditionType(Int32 pkID);

        //Roles
        IQueryable<Role> GetRoles();
        Task<Role> GetRole(Int32 ID);
        Task<Role> Add(Role item);
        Task<IEnumerable<Role>> Add(List<Role> items);
        Task<Role> Update(Int32 pkId, Role item);
        Task DeleteRole(Int32 pkID);

        //RoughnessTypes
        IQueryable<RoughnessType> GetRoughnessTypes();
        Task<RoughnessType> GetRoughnessType(Int32 ID);
        Task<RoughnessType> Add(RoughnessType item);
        Task<IEnumerable<RoughnessType>> Add(List<RoughnessType> items);
        Task<RoughnessType> Update(Int32 pkId, RoughnessType item);
        Task DeleteRoughnessType(Int32 pkID);

        //Sites
        IQueryable<Site> GetSites();
        Task<Site> GetSite(Int32 ID);
        Task<Site> Add(Site item);
        Task<IEnumerable<Site>> Add(List<Site> items);
        Task<Site> Update(Int32 pkId, Site item);
        Task DeleteSite(Int32 pkID);

        //StageTypes
        IQueryable<StageType> GetStageTypes();
        Task<StageType> GetStageType(Int32 ID);
        Task<StageType> Add(StageType item);
        Task<IEnumerable<StageType>> Add(List<StageType> items);
        Task<StageType> Update(Int32 pkId, StageType item);
        Task DeleteStageType(Int32 pkID);

        //WeatherConditions (Available via Event)

        //WeatherConditionTypes
        IQueryable<WeatherConditionType> GetWeatherConditionTypes();
        Task<WeatherConditionType> GetWeatherConditionType(Int32 ID);
        Task<WeatherConditionType> Add(WeatherConditionType item);
        Task<IEnumerable<WeatherConditionType>> Add(List<WeatherConditionType> items);
        Task<WeatherConditionType> Update(Int32 pkId, WeatherConditionType item);
        Task DeleteWeatherConditionType(Int32 pkID);
    }

    public class IceJamsAgent:DBAgentBase, IIceJamsAgent
    {
        #region Properties
        
        #endregion
        #region Constructor
        public IceJamsAgent(IceJamsDBContext context):base (context)
        {
            //optimize query for disconnected databases.
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
        }
        #endregion
        #region Methods
        #region Agencies
        public IQueryable<Agency> GetAgencies()
        {
            return this.Select<Agency>();
        }
        public Task<Agency> GetAgency(Int32 ID)
        {
            return this.Find<Agency>(ID);
        }
        public Task<Agency> Add(Agency item)
        {
            return this.Add<Agency>(item);
        }
        public Task<IEnumerable<Agency>> Add(List<Agency> items)
        {
            return this.Add<Agency>(items);
        }
        public Task<Agency> Update(Int32 pkId, Agency item)
        {
            return this.Update<Agency>(pkId, item);
        }
        public Task DeleteAgency(Int32 pkID)
        {
            return this.Delete<Agency>(pkID);
        }
        #endregion
        #region DamageTypes
        public IQueryable<DamageType> GetDamageTypes()
        {
            return this.Select<DamageType>();
        }
        public Task<DamageType> GetDamageType(Int32 ID)
        {
            return this.Find<DamageType>(ID);
        }
        public Task<DamageType> Add(DamageType item)
        {
            return this.Add<DamageType>(item);
        }
        public Task<IEnumerable<DamageType>> Add(List<DamageType> items)
        {
            return this.Add<DamageType>(items);
        }
        public Task<DamageType> Update(Int32 pkId, DamageType item)
        {
            return this.Update<DamageType>(pkId, item);
        }
        public Task DeleteDamageType(Int32 pkID)
        {
            return this.Delete<DamageType>(pkID);
        }
        #endregion
        #region FileTypes
        public IQueryable<FileType> GetFileTypes()
        {
            return this.Select<FileType>();
        }
        public Task<FileType> GetFileType(Int32 ID)
        {
            return this.Find<FileType>(ID);
        }
        public Task<FileType> Add(FileType item)
        {
            return this.Add<FileType>(item);
        }
        public Task<IEnumerable<FileType>> Add(List<FileType> items)
        {
            return this.Add<FileType>(items);
        }
        public Task<FileType> Update(Int32 pkId, FileType item)
        {
            return this.Update<FileType>(pkId, item);
        }
        public Task DeleteFileType(Int32 pkID)

        {
            return this.Delete<FileType>(pkID);
        }
        #endregion
        #region IceConditionTypes
        public IQueryable<IceConditionType> GetIceConditionTypes()
        {
            return this.Select<IceConditionType>();
        }
        public Task<IceConditionType> GetIceConditionType(Int32 ID)
        {
            return this.Find<IceConditionType>(ID);
        }
        public Task<IceConditionType> Add(IceConditionType item)
        {
            return this.Add<IceConditionType>(item);
        }
        public Task<IEnumerable<IceConditionType>> Add(List<IceConditionType> items)
        {
            return this.Add<IceConditionType>(items);
        }
        public Task<IceConditionType> Update(Int32 pkId, IceConditionType item)
        {
            return this.Update<IceConditionType>(pkId, item);
        }
        public Task DeleteIceConditionType(Int32 pkID)
        {
            return this.Delete<IceConditionType>(pkID);
        }
        #endregion
        #region JamTypes
        public IQueryable<JamType> GetJamTypes()
        {
            return this.Select<JamType>();
        }
        public Task<JamType> GetJamType(Int32 ID)
        {
            return this.Find<JamType>(ID);
        }
        public Task<JamType> Add(JamType item)
        {
            return this.Add<JamType>(item);
        }
        public Task<IEnumerable<JamType>> Add(List<JamType> items)
        {
            return this.Add<JamType>(items);
        }
        public Task<JamType> Update(Int32 pkId, JamType item)
        {
            return this.Update<JamType>(pkId, item);
        }
        public Task DeleteJamType(Int32 pkID)
        {
            return this.Delete<JamType>(pkID);
        }
        #endregion
        #region Observer
        public IBasicUser GetUserByUsername(string username)
        {
            try
            {

                return Select<Observer>().Include(p => p.Role).Where(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase))
                    .Select(u => new User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Role = u.Role.Name,
                        RoleID = u.RoleID,
                        ID = u.ID,
                        Username = u.Username,
                        Salt = u.Salt,
                        password = u.Password
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public IQueryable<Observer> GetObservers()
        {
            return this.Select<Observer>().Include(o=>o.Agency).Include(o=>o.Role).Select(o => new Observer() {
                ID = o.ID,
                AgencyID = o.AgencyID,
                Agency = o.Agency,
                Email = o.Email,
                FirstName = o.FirstName,
                LastName = o.LastName,
                OtherInfo = o.OtherInfo,
                PrimaryPhone = o.PrimaryPhone,
                RoleID = o.RoleID,
                Role = o.Role,
                SecondaryPhone = o.SecondaryPhone,
                Username = o.Username
            });
        }
        public Task<Observer> GetObserver(int ID)
        {
            return Task.Run(() => { return this.GetObservers().FirstOrDefault(o=>o.ID ==ID);});
        }
        public Task<Observer> FindObserver(int ID)
        {
            return this.Find<Observer>(ID);
        }
        public Task<Observer> Add(Observer item)
        {
            return this.Add<Observer>(item);
        }
        public Task<IEnumerable<Observer>> Add(List<Observer> items)
        {
            return this.Add<Observer>(items);
        }
        public Task<Observer> Update(int pkId, Observer item)
        {
            return this.Update<Observer>(pkId, item);
        }
        public Task DeleteObserver(int pkID)
        {
            return this.Delete<Observer>(pkID);
        }
        #endregion        
        #region RiverConditionTypes
        public IQueryable<RiverConditionType> GetRiverConditionTypes()
        {
            return this.Select<RiverConditionType>();
        }
        public Task<RiverConditionType> GetRiverConditionType(Int32 ID)
        {
            return this.Find<RiverConditionType>(ID);
        }
        public Task<RiverConditionType> Add(RiverConditionType item)
        {
            return this.Add<RiverConditionType>(item);
        }
        public Task<IEnumerable<RiverConditionType>> Add(List<RiverConditionType> items)
        {
            return this.Add<RiverConditionType>(items);
        }
        public Task<RiverConditionType> Update(Int32 pkId, RiverConditionType item)
        {
            return this.Update<RiverConditionType>(pkId, item);
        }
        public Task DeleteRiverConditionType(Int32 pkID)
        {
            return this.Delete<RiverConditionType>(pkID);
        }
        #endregion
        #region Roles
        public IQueryable<Role> GetRoles()
        {
            return this.Select<Role>();
        }
        public Task<Role> GetRole(int ID)
        {
            return this.Find<Role>(ID);
        }
        public Task<Role> Add(Role item)
        {
            return this.Add<Role>(item);
        }
        public Task<IEnumerable<Role>> Add(List<Role> items)
        {
            return this.Add<Role>(items);
        }
        public Task<Role> Update(int pkId, Role item)
        {
            return this.Update<Role>(pkId, item);
        }
        public Task DeleteRole(int pkID)
        {
            return this.Delete<Role>(pkID);
        }
        #endregion        
        #region RoughnessTypes
        public IQueryable<RoughnessType> GetRoughnessTypes()
        {
            return this.Select<RoughnessType>();
        }
        public Task<RoughnessType> GetRoughnessType(Int32 ID)
        {
            return this.Find<RoughnessType>(ID);
        }
        public Task<RoughnessType> Add(RoughnessType item)
        {
            return this.Add<RoughnessType>(item);
        }
        public Task<IEnumerable<RoughnessType>> Add(List<RoughnessType> items)
        {
            return this.Add<RoughnessType>(items);
        }
        public Task<RoughnessType> Update(Int32 pkId, RoughnessType item)
        {
            return this.Update<RoughnessType>(pkId, item);
        }
        public Task DeleteRoughnessType(Int32 pkID)
        {
            return this.Delete<RoughnessType>(pkID);
        }
        #endregion
        #region Sites
        public IQueryable<Site> GetSites()
        {
            return this.Select<Site>();
        }
        public Task<Site> GetSite(Int32 ID)
        {
            return this.Find<Site>(ID);
        }
        public Task<Site> Add(Site item)
        {
            return this.Add<Site>(item);
        }
        public Task<IEnumerable<Site>> Add(List<Site> items)
        {
            return this.Add<Site>(items);
        }
        public Task<Site> Update(Int32 pkId, Site item)
        {
            return this.Update<Site>(pkId, item);
        }
        public Task DeleteSite(Int32 pkID)
        {
            return this.Delete<Site>(pkID);
        }
        #endregion
        #region StageTypes
        public IQueryable<StageType> GetStageTypes()
        {
            return this.Select<StageType>();
        }
        public Task<StageType> GetStageType(Int32 ID)
        {
            return this.Find<StageType>(ID);
        }
        public Task<StageType> Add(StageType item)
        {
            return this.Add<StageType>(item);
        }
        public Task<IEnumerable<StageType>> Add(List<StageType> items)
        {
            return this.Add<StageType>(items);
        }
        public Task<StageType> Update(Int32 pkId, StageType item)
        {
            return this.Update<StageType>(pkId, item);
        }
        public Task DeleteStageType(Int32 pkID)
        {
            return this.Delete<StageType>(pkID);
        }
        #endregion
        #region WeatherConditionTypes
        public IQueryable<WeatherConditionType> GetWeatherConditionTypes()
        {
            return this.Select<WeatherConditionType>();
        }
        public Task<WeatherConditionType> GetWeatherConditionType(Int32 ID)
        {
            return this.Find<WeatherConditionType>(ID);
        }
        public Task<WeatherConditionType> Add(WeatherConditionType item)
        {
            return this.Add<WeatherConditionType>(item);
        }
        public Task<IEnumerable<WeatherConditionType>> Add(List<WeatherConditionType> items)
        {
            return this.Add<WeatherConditionType>(items);
        }
        public Task<WeatherConditionType> Update(Int32 pkId, WeatherConditionType item)
        {
            return this.Update<WeatherConditionType>(pkId, item);
        }
        public Task DeleteWeatherConditionType(Int32 pkID)
        {
            return this.Delete<WeatherConditionType>(pkID);
        }
        #endregion
        #endregion
        #region HELPER METHODS
        private Task Delete<T>(Int32 id) where T : class, new()
        {
            var entity = base.Find<T>(id).Result;
            if (entity == null) return new Task(null);
            return base.Delete<T>(entity);
        }
        private void sm(string message, MessageType type = MessageType.info)
        {
            this.Messages.Add(new Message() { msg=message, type = type });
        }
        #endregion
    }

}