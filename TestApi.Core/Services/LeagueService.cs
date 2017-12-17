using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Data.Entities;
using TestApi.Core.Models;
using TestApi.Core.Infrastructure;

namespace TestApi.Core.Services
{
    public class LeagueService
    {
        #region Methods

        #region Public

        public ResultBase<LeagueModel> GetLeagueById(int idLeague)
        {
            var resultValidation = ValidateIdLeague(idLeague);
            if (!resultValidation.Success)
            {
                return new ResultBase<LeagueModel>()
                {
                    Success = false,
                    Message = resultValidation.Message
                };
            }

            var leagueModel = new LeagueModel();
            leagueModel.LeagueId = 1;
            leagueModel.LeagueName = "Primera Division";
            leagueModel.Country = "Espanya";
            leagueModel.CountryId = 1;
            leagueModel.SortIndex = 1;
            leagueModel.IsTopLeague = true;

            var result = new ResultBase<LeagueModel>()
            {
                Success = true,
                Result = leagueModel
            };
            return result;
        }

        public ResultBase<List<LeagueModel>> GetLeagues()
        {
            var leagueModel1 = new LeagueModel();
            leagueModel1.LeagueId = 1;
            leagueModel1.LeagueName = "Primera Division";
            leagueModel1.Country = "Espanya";
            leagueModel1.CountryId = 1;
            leagueModel1.SortIndex = 1;
            leagueModel1.IsTopLeague = true;
            var leagueModel2 = new LeagueModel();
            leagueModel2.LeagueId = 2;
            leagueModel2.LeagueName = "Segunda Division";
            leagueModel2.Country = "Espanya";
            leagueModel2.CountryId = 1;
            leagueModel2.SortIndex = 2;
            leagueModel2.IsTopLeague = true;
            var leagueModel3 = new LeagueModel();
            leagueModel3.LeagueId = 3;
            leagueModel3.LeagueName = "Segunda Division B";
            leagueModel3.Country = "Espanya";
            leagueModel3.CountryId = 1;
            leagueModel3.SortIndex = 3;
            leagueModel3.IsTopLeague = true;

            var leagues = new List<LeagueModel>();
            leagues.Add(leagueModel1);
            leagues.Add(leagueModel2);
            leagues.Add(leagueModel3);
            var result = new ResultBase<List<LeagueModel>>()
            {
                Success = true,
                Result = leagues
            };
            return result;
        }

        #endregion

        #region Private

        private ResultBase<bool> ValidateIdLeague(int idLeague)
        {
            var result = new ResultBase<bool>();
            if (idLeague > 1)
            {
                result.Success = false;
                result.Message = "IdLeague doesn't exist";
                return result;
            }
            result.Success = true;
            return result;
        }

        private LeagueModel ToLeagueModel(League league)
        {
            return new LeagueModel();
        }

        #endregion

        #endregion
    }
}
