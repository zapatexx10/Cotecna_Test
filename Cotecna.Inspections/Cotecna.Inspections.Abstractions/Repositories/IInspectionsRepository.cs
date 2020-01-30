using Cotecna.Inspections.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotecna.Inspections.Abstractions.Repositories
{
    public interface IInspectionsRepository
    {
        List<Inspection> GetAllInspections();
        List<Inspection> GetInspectionsByInspectorId(int rentalId);
        bool AddInspection(Inspection inspectionToAdd);
        bool UpdateInspection(Inspection inspectionToUpdate);
        bool DeleteInspectionById(int inspectionId);
        List<Inspector> GetInspectors();
    }
}
