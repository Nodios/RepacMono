﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;

namespace Lost.Repository.Common
{
    public interface ILostRepository
    {
        //This might go to service layer
        List<ILostPerson> GetByLocation(string location);
        List<ILostPerson> GetByCountry(string country);
        List<ILostPerson> GetByReportDate(DateTime reportDate);
        List<ILostPerson> GetByDateLastSeen(DateTime lastSeen);
        List<ILostPerson> GetByLocationLastSeen(string lastSeen);
        ILostPerson GetLostPersonById(int id);

        //CRUD
        bool ReportMissingPerson(int id);
        List<ILostPerson> GetAllLostPersons();
        List<IRedCross> GetAllRedCrosses();
        bool RemoveMissingPerson(int id);

    }
}
