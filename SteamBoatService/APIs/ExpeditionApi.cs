using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.ServiceModel.Web;
using SteamBoatService.Infrastructure;
using SteamBoatService.Resources;
using SteamBoatService.Services;

namespace SteamBoatService.APIs {

    public class ExpeditionApi {

        private VariableSource source = new Expedition();

        [WebGet(UriTemplate = "{id}")]
        public Variable GetVariable(int id)
        {
            var result = source.GetVariable(id);

            return result;
        }
    }
}
