using Cotecna.Inspections.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotecna.Inspections.Abstractions.Services
{
    public interface IInspectionService
    {
        List<Inspection> GetAllInspections();
        List<Inspection> GetInspectionsByInspectorId(int rentalId);
        bool AddInspection(Inspection inspectionToAdd);
        bool UpdateInspectionById(int inspectionId, Inspection inspectionToUpdate);
        bool DeleteInspectionById(int inspectionId);
        List<Inspector> GetInspectors();
    }
}
